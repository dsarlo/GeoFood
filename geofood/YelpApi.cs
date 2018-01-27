using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yelp.Api;

namespace GeoFood
   
{
    class YelpApi
    {
        // Instantiating the Yelp Client, Client ID and Client Secret (from the API/yelp-based application registration page) passed in respectively

        IList<Yelp.Api.Models.BusinessResponse> _restaurantList = new List<Yelp.Api.Models.BusinessResponse>();

        /// <summary>
        /// Generate a list of 50 restaurants based on the user food preferences and coordinates (latitude and longitude).
        /// </summary>
        /// <returns>50 restaurants in close proximity to provided coordinates that match food preferences of user</returns>
        public async void GenerateRestaurantList(double latitude, double longitude, String preference)
        {
            var request = new Yelp.Api.Models.SearchRequest();
            request.Latitude = latitude;
            request.Longitude = longitude;
            request.Term = preference;
            request.MaxResults = 50;
            request.OpenNow = true;


            Client client = new Client("3MShj1xjzQBXVbXGSuc_qw", "2Y6bOEKXIHvRF9pQ42dt6YLSS66kEChB5NrTmkzLJMpM8TLxwohjitpBjNUhDZrb");
            var results = await client.SearchBusinessesAllAsync(request);
            _restaurantList = results.Businesses;
            Console.Write(_restaurantList[0].Name);
        }

        /// <summary>
        /// Randomly selects a restaurant from the list of the 50 previously found. This function can only execute after execution of "GenerateRestaurantList".
        /// </summary>
        /// <returns>A random restaurant</returns>
        public Model.Restaurant RandomRestaurant()
        {
            if (_restaurantList.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("You've gone through all of the restaurants!");
                return new Model.Restaurant("https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055", "", 0f, "");
            }

            Random random = new Random();
            int index = random.Next(_restaurantList.Count);

            String photo = _restaurantList[index].ImageUrl;
            String name = _restaurantList[index].Name;
            float rating = _restaurantList[index].Rating;
            String price = _restaurantList[index].Price;

            Model.Restaurant restaurant = new Model.Restaurant(photo, name, rating, price);
            _restaurantList.RemoveAt(index);
            return restaurant;
        }

    }
}
