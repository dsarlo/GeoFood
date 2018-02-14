using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Yelp.Api;
using Yelp.Api.Models;

namespace GeoFood.Model
{
    internal class YelpApi
    {
        private IList<BusinessResponse> _restaurantList;
        private readonly Client _yelpClient;

        public Dictionary<int, IList<BusinessResponse>> PreloadedRestaurantSearches { get; internal set; }

        private const string SadFaceUrl =
            "https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055";

        public YelpApi()
        {
            _yelpClient = new Client("3MShj1xjzQBXVbXGSuc_qw", "2Y6bOEKXIHvRF9pQ42dt6YLSS66kEChB5NrTmkzLJMpM8TLxwohjitpBjNUhDZrb");
            _restaurantList = new List<BusinessResponse>();
        }

        /// <summary>
        /// Generate a list of 50 restaurants based on the user food preferences and coordinates (latitude and longitude). 
        /// Does this for each of the preferences and stores them in a dictionary in order to speed up user interaction with the UI.
        /// </summary>
        /// <returns>NONE</returns>
        public async Task<bool> PreloadRestaurantSearches(double latitude, double longitude, object[] preferences)
        {
            PreloadedRestaurantSearches = new Dictionary<int, IList<BusinessResponse>>();

            SearchRequest request = new SearchRequest
            {
                Latitude = latitude,
                Longitude = longitude,
                MaxResults = 50,
                OpenNow = true
            };

            for(int currentPref = 0; currentPref < preferences.Length; currentPref++)
            {
                request.Term = preferences[currentPref].ToString();

                SearchResponse results = await _yelpClient.SearchBusinessesAllAsync(request);//TODO timeout exception check
                PreloadedRestaurantSearches.Add(currentPref, results.Businesses);
            }

            string dictionaryAsString = JsonConvert.SerializeObject(PreloadedRestaurantSearches);
            Properties.Settings.Default.PreloadedBusinesses = dictionaryAsString;
            Properties.Settings.Default.Save();

            return true;
        }

        public void ChangePreferredRestaurantType(int preference)
        {
            _restaurantList = PreloadedRestaurantSearches[preference];
        }

        /// <summary>
        /// Randomly selects a restaurant from the list of the 50 previously found. This function can only execute after execution of "GenerateRestaurantList".
        /// </summary>
        /// <returns>A random restaurant</returns>
        public Restaurant RandomRestaurant()
        {
            if (_restaurantList.Count == 0)
            {
                //System.Windows.Forms.MessageBox.Show(@"You've gone through all of the restaurants!");
                return new Restaurant(SadFaceUrl, "", -1f, "");
            }

            Random random = new Random();
            int index = random.Next(_restaurantList.Count);

            string photoUrl = _restaurantList[index].ImageUrl;
            string photo = string.IsNullOrEmpty(photoUrl) ? SadFaceUrl : photoUrl;
            string name = _restaurantList[index].Name;
            float rating = _restaurantList[index].Rating;
            string restaurantPrice = _restaurantList[index].Price;
            string price = string.IsNullOrEmpty(restaurantPrice) ? "$" : restaurantPrice;

            //TODO maybe dictionary that contains already visited food options (boolean array) and an index indicating the restaurant list (from the preload dictionary), but for now, it will be random and continue forever.

            return new Restaurant(photo, name, rating, price);
        }

    }
}
