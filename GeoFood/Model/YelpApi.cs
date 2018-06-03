using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yelp.Api;
using Yelp.Api.Models;

namespace GeoFood.Model
{
    internal class YelpApi
    {
        private List<Restaurant> _orderedRestaurants;
        private readonly Client _yelpClient;
        private int _orderedRestaurantIndex;

        private const string SadFaceUrl = "https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055";

        private const string ApiKey = "9JvzR_sWVuhipG77MtIMpAGwvjaxUUw1ZEPf9EaTRqfhVg_r0-83nZZk_ArpryLeObEcb6yRpVwHZBHS-cwQZgEo3SBN6FvAljQUlig2GXNS_kNLVOqDNN5if76YWnYx";

        public YelpApi()
        {
            _yelpClient = new Client(ApiKey);
        }

        public async Task<bool> ChangePreferredRestaurantType(double latitude, double longitude, string preference)
        {
            List<Restaurant> restaurantList = new List<Restaurant>();

            SearchRequest request = new SearchRequest
            {
                Latitude = latitude,
                Longitude = longitude,
                MaxResults = 50,
                OpenNow = true,
                Term = preference,
                Radius = 25000
            };

            SearchResponse results = await _yelpClient.SearchBusinessesAllAsync(request);//TODO what happens when we get back 0 results?
            foreach(BusinessResponse business in results.Businesses)
            {
                string imageUrl = business.ImageUrl;
                string restaurantPic = string.IsNullOrEmpty(business.ImageUrl) ? SadFaceUrl : imageUrl;
                string restaurantPrice = business.Price;
                string price = string.IsNullOrEmpty(restaurantPrice) ? "$" : restaurantPrice;//TODO make restaurant class handle nullorempty case?
                float distance = (float)Math.Round(business.Distance * 0.001609344f, 1);
                string website = business.Url;

                restaurantList.Add(new Restaurant(restaurantPic, business.Name, business.Rating, price, distance, website));
            }

            Random rand = new Random();
            _orderedRestaurants = restaurantList.OrderBy(restaurant => rand.Next()).ToList();

            return true;
        }

        /// <summary>
        /// Selects a restaurant from the randomly ordered list of restaurants we cached earlier.
        /// When we hit the end of the list, we reset the index to the beginning and reorder the list in a new random order.
        /// </summary>
        /// <returns>A random restaurant</returns>
        public Restaurant GetNextRestaurant()
        {
            Restaurant nextRestaurant = _orderedRestaurants[_orderedRestaurantIndex];

            if (_orderedRestaurantIndex == _orderedRestaurants.Count - 1)
            {
                _orderedRestaurantIndex = 0;
                Random rand = new Random();
                _orderedRestaurants = _orderedRestaurants.OrderBy(restaurant => rand.Next()).ToList();
            }
            else
            {
                _orderedRestaurantIndex++;
            }

            return nextRestaurant;
        }
    }
}
