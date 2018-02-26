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
        private IList<BusinessResponse> _restaurantList;
        private readonly Client _yelpClient;

        public Dictionary<int, IList<Restaurant>> PreloadedRestaurantSearches { get; internal set; }

        private const string SadFaceUrl =
            "https://cdn.shopify.com/s/files/1/1061/1924/products/Sad_Face_Emoji_large.png?v=1480481055";

        public YelpApi()
        {
            _yelpClient = new Client("3MShj1xjzQBXVbXGSuc_qw", "2Y6bOEKXIHvRF9pQ42dt6YLSS66kEChB5NrTmkzLJMpM8TLxwohjitpBjNUhDZrb");
            _restaurantList = new List<BusinessResponse>();
        }

        public async Task<bool> ChangePreferredRestaurantType(double latitude, double longitude, string preference)
        {
            SearchRequest request = new SearchRequest
            {
                Latitude = latitude,
                Longitude = longitude,
                MaxResults = 50,
                OpenNow = true,
                Term = preference
            };

            SearchResponse results = await _yelpClient.SearchBusinessesAllAsync(request);//TODO timeout exception check
            Console.WriteLine("LOAD COMPLETE");
            _restaurantList = results.Businesses;

            return true;
        }

        /// <summary>
        /// Randomly selects a restaurant from the list of the 50 previously found. This function can only execute after execution of "GenerateRestaurantList".
        /// </summary>
        /// <returns>A random restaurant</returns>
        public Restaurant RandomRestaurant()
        {
            if (_restaurantList.Count == 0)
            {
                return new Restaurant(SadFaceUrl, "", -1f, "");
            }

            Random random = new Random();
            int index = random.Next(_restaurantList.Count);

            //TODO maybe dictionary that contains already visited food options (boolean array) and an index indicating the restaurant list (from the preload dictionary), but for now, it will be random and continue forever.
            BusinessResponse chosenBusiness = _restaurantList[index];

            string imageUrl = chosenBusiness.ImageUrl;
            string restaurantPic = string.IsNullOrEmpty(chosenBusiness.ImageUrl) ? SadFaceUrl : imageUrl;
            string restaurantPrice = chosenBusiness.Price;
            string price = string.IsNullOrEmpty(restaurantPrice) ? "$" : restaurantPrice;//TODO make restaurant class handle nullorempty case?
            float distance = chosenBusiness.Distance;
            string website = chosenBusiness.Url;

            return new Restaurant(restaurantPic, chosenBusiness.Name, chosenBusiness.Rating, price, distance, website);
        }

    }
}
