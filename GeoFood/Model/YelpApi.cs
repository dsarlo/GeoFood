using System;
using System.Collections.Generic;
using Yelp.Api;
using Yelp.Api.Models;

namespace GeoFood.Model
{
    internal class YelpApi
    {
        private IList<BusinessResponse> _restaurantList = new List<BusinessResponse>();

        /// <summary>
        /// Generate a list of 50 restaurants based on the user food preferences and coordinates (latitude and longitude).
        /// </summary>
        /// <returns>50 restaurants in close proximity to provided coordinates that match food preferences of user</returns>
        public async void GenerateRestaurantList(double latitude, double longitude, string preference)
        {
            SearchRequest request = new SearchRequest
            {
                Latitude = latitude,
                Longitude = longitude,
                Term = preference,
                MaxResults = 50,
                OpenNow = true
            };


            Client client = new Client("3MShj1xjzQBXVbXGSuc_qw", "2Y6bOEKXIHvRF9pQ42dt6YLSS66kEChB5NrTmkzLJMpM8TLxwohjitpBjNUhDZrb");
            SearchResponse results = await client.SearchBusinessesAllAsync(request);
            _restaurantList = results.Businesses;
        }

        /// <summary>
        /// Randomly selects a restaurant from the list of the 50 previously found. This function can only execute after execution of "GenerateRestaurantList".
        /// </summary>
        /// <returns>A random restaurant</returns>
        public Restaurant RandomRestaurant()
        {
            if (_restaurantList.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show(@"You've gone through all of the restaurants!");
                return new Restaurant("https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055", "", -1f, "");
            }

            Random random = new Random();
            int index = random.Next(_restaurantList.Count);

            string photo = _restaurantList[index].ImageUrl;
            string name = _restaurantList[index].Name;
            float rating = _restaurantList[index].Rating;
            string restaurantPrice = _restaurantList[index].Price;
            string price = string.IsNullOrEmpty(restaurantPrice) ? "$" : restaurantPrice;

            Restaurant restaurant = new Restaurant(photo, name, rating, price);
            _restaurantList.RemoveAt(index);
            return restaurant;
        }

    }
}
