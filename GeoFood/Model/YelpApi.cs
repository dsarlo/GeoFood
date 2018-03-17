using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yelp.Api;
using Yelp.Api.Models;

namespace GeoFood.Model
{
    internal class YelpApi
    {
        private readonly IList<Restaurant> _restaurantList;
        private readonly Client _yelpClient;

        private const string SadFaceUrl =
            "https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055";

        private const string ApiKey = "9JvzR_sWVuhipG77MtIMpAGwvjaxUUw1ZEPf9EaTRqfhVg_r0-83nZZk_ArpryLeObEcb6yRpVwHZBHS-cwQZgEo3SBN6FvAljQUlig2GXNS_kNLVOqDNN5if76YWnYx";

        public YelpApi()
        {
            _yelpClient = new Client(ApiKey);
            _restaurantList = new List<Restaurant>();
        }

        public async Task<bool> ChangePreferredRestaurantType(double latitude, double longitude, string preference)
        {
            SearchRequest request = new SearchRequest
            {
                Latitude = latitude,
                Longitude = longitude,
                MaxResults = 50,
                OpenNow = true,
                Term = preference,
                Radius = 25000
            };

            SearchResponse results = await _yelpClient.SearchBusinessesAllAsync(request);
            foreach(BusinessResponse business in results.Businesses)
            {
                string imageUrl = business.ImageUrl;
                string restaurantPic = string.IsNullOrEmpty(business.ImageUrl) ? SadFaceUrl : imageUrl;
                string restaurantPrice = business.Price;
                string price = string.IsNullOrEmpty(restaurantPrice) ? "$" : restaurantPrice;//TODO make restaurant class handle nullorempty case?
                float distance = (float)Math.Round(business.Distance * 0.001609344f, 1);
                string website = business.Url;

                _restaurantList.Add(new Restaurant(restaurantPic, business.Name, business.Rating, price, distance, website));
            }

            return true;
        }

        /// <summary>
        /// Randomly selects a restaurant from the list of the 50 previously found. This function can only execute after execution of "GenerateRestaurantList".
        /// </summary>
        /// <returns>A random restaurant</returns>
        public Restaurant RandomRestaurant()
        {
            Random random = new Random();
            int index = random.Next(_restaurantList.Count);//TODO handle same restaurant twice+

            return _restaurantList[index];
        }

    }
}
