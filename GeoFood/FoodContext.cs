
using System.Device.Location;
using GeoFood.Model;

namespace GeoFood
{
    internal class FoodContext //Context for communicating between property classes and the GUI.
    {
        private double _latitude, _longitude;
        private GeoCoordinateWatcher _geoWatcher;

        public FoodContext()
        {
            GetCurrentLocation();
            //GatherListOfRestaurants();
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
        }

        public Restaurant GetRandomRestaurant(string preference)
        {
            //use yelp api to create a randomized restaurant object based on the given preference here^
            return null;
        }
    }
}
