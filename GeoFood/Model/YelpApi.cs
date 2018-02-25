using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Yelp.Api;
using Yelp.Api.Models;

namespace GeoFood.Model
{
    internal class YelpApi
    {
        private IList<Restaurant> _restaurantList;
        private readonly Client _yelpClient;

        public Dictionary<int, IList<Restaurant>> PreloadedRestaurantSearches { get; internal set; }

        private const string SadFaceUrl =
            "https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055";

        public YelpApi()
        {
            _yelpClient = new Client("3MShj1xjzQBXVbXGSuc_qw", "2Y6bOEKXIHvRF9pQ42dt6YLSS66kEChB5NrTmkzLJMpM8TLxwohjitpBjNUhDZrb");
            _restaurantList = new List<Restaurant>();
        }

        /// <summary>
        /// Generate a list of 50 restaurants based on the user food preferences and coordinates (latitude and longitude). 
        /// Does this for each of the preferences and stores them in a dictionary in order to speed up user interaction with the UI.
        /// </summary>
        /// <returns>NONE</returns>
        public async Task<bool> PreloadRestaurantSearches(double latitude, double longitude, object[] preferences)
        {
            PreloadedRestaurantSearches = new Dictionary<int, IList<Restaurant>>();

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

                IList<Restaurant> businessesForCurrentPreference = new List<Restaurant>();

                foreach (BusinessResponse business in results.Businesses)
                {
                    string imageUrl = business.ImageUrl;
                    string restaurantPic = string.IsNullOrEmpty(business.ImageUrl) ? SadFaceUrl : imageUrl;

                    string restaurantPrice = business.Price;
                    string price = string.IsNullOrEmpty(restaurantPrice) ? "$" : restaurantPrice;//TODO make restaurant class handle nullorempty case?

                    businessesForCurrentPreference.Add(new Restaurant(restaurantPic, business.Name, business.Rating, price));
                }
                PreloadedRestaurantSearches.Add(currentPref, businessesForCurrentPreference);
            }

            Properties.Settings.Default.PreloadedBusinesses = JsonConvert.SerializeObject(PreloadedRestaurantSearches);
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
            Random random = new Random();
            int chosenRestaurant = random.Next(_restaurantList.Count);

            //TODO maybe dictionary that contains already visited food options (boolean array) and an index indicating the restaurant list (from the preload dictionary), but for now, it will be random and continue forever.

            return _restaurantList[chosenRestaurant];
        }

    }
}
