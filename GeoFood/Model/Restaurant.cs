using System.Drawing;

namespace GeoFood.Model
{
    internal class Restaurant
    {
        public Restaurant(string picture, string name, float rating, string price)
        {
            Picture = picture;
            Name = name;
            Rating = rating;
            Price = price;
        }

        public string Picture { get; }

        public string Name { get; }

        public float Rating { get; }

        public string Price { get; }
    }
}
