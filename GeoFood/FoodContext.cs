using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Drawing;
using GeoFood.Model;
using Newtonsoft.Json;
using Yelp.Api.Models;

namespace GeoFood
{
    internal class FoodContext //Context for communicating between property classes and the GUI.
    {
        private double _latitude, _longitude;
        private GeoCoordinateWatcher _geoWatcher;
        private readonly YelpApi _yelp;

        private bool _preloadFinished;
        public const string PropertyNamePreloadFinished = "PreloadFinished";
        public event PropertyChangedEventHandler PropertyChanged;

        public static object[] FoodPreferences = { "Fast Food", "Bar", "American", "Japanese", "Chinese", "Thai", "German", "Italian", "Mediterranean", "Polish", "Seafood", "Mexican" };

        public FoodContext()
        {
            _yelp = new YelpApi();
            GetCurrentLocation();
        }

        private void GetCurrentLocation()
        {
            _geoWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            _geoWatcher.PositionChanged += PositionChanged;
            _geoWatcher.Start();
        }

        private void PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            GeoCoordinate currentLocation = e.Position.Location;
            _latitude = currentLocation.Latitude;
            _longitude = currentLocation.Longitude;
            _geoWatcher.Stop();

            //ShouldWePreload();

            //Unhook the positionchanged event so preload is only called once
            _geoWatcher.PositionChanged -= PositionChanged;
            _geoWatcher.Dispose();
        }

        private void ShouldWePreload()
        {
            string currentLocationAsString = _latitude + ";" + _longitude;

            if (string.IsNullOrEmpty(Properties.Settings.Default.PreloadedBusinesses)
                || currentLocationAsString != Properties.Settings.Default.LastSavedLocation)
            {
                PreloadRestaurantSearches();
                Properties.Settings.Default.LastSavedLocation = _latitude + ";" + _longitude;
                Properties.Settings.Default.Save();
            }
            else
            {
                PreloadFinished = true;
                _yelp.PreloadedRestaurantSearches = JsonConvert.DeserializeObject<Dictionary<int, IList<Restaurant>>>(Properties.Settings.Default.PreloadedBusinesses);
            }
        }

        //#GOODTOKNOW can only be called if a preference has been chosen otherwise current restaurant will be null
        public Restaurant GetRandomRestaurant()
        {
            return _yelp.RandomRestaurant();
        }

        public async void PreloadRestaurantSearches()
        {
            PreloadFinished = await _yelp.PreloadRestaurantSearches(_latitude, _longitude, FoodPreferences);
        }

        public void ChangeUserPreference(int preference)
        {
            string currentPref = FoodPreferences[preference].ToString();
            _yelp.ChangePreferredRestaurantType(_latitude, _longitude, currentPref);
        }

        internal bool PreloadFinished
        {
            get => _preloadFinished;
            private set
            {
                _preloadFinished = value;
                OnPropertyChanged(PropertyNamePreloadFinished);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
