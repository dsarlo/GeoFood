using System.ComponentModel;
using System.Device.Location;
using GeoFood.Model;

namespace GeoFood
{
    internal class FoodContext //Context for communicating between property classes and the GUI.
    {
        private double _latitude, _longitude;
        private GeoCoordinateWatcher _geoWatcher;
        private readonly YelpApi _yelp;

        private bool _restaurantLoadFinished;
        public const string PropertyNameLoadFinished = "RestaurantLoadFinished";
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

            //Unhook the positionchanged event so preload is only called once
            _geoWatcher.PositionChanged -= PositionChanged;
            _geoWatcher.Dispose();
        }

        //#GOODTOKNOW can only be called if a preference has been chosen otherwise current restaurant will be null
        public Restaurant GetRandomRestaurant()
        {
            return _yelp.RandomRestaurant();
        }

        public async void OnUserPreferenceChanged(int preference)
        {
            string currentPref = FoodPreferences[preference].ToString();
            RestaurantLoadFinished = await _yelp.ChangePreferredRestaurantType(_latitude, _longitude, currentPref);
        }

        internal bool RestaurantLoadFinished
        {
            get => _restaurantLoadFinished;
            private set
            {
                _restaurantLoadFinished = value;
                OnPropertyChanged(PropertyNameLoadFinished);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
