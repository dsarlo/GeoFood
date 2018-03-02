using System.Drawing;

namespace GeoFood.Model
{
    internal class Restaurant
    {
        public Restaurant(string picture, string name, float rating, string price, float distance, string website)
        {
            Picture = picture;
            Name = name;
            Rating = RatingLookup(rating);
            Price = price;
            Distance = distance;
            Website = website;
        }

        public string Picture { get; }

        public string Name { get; }

        public Bitmap Rating { get; }

        public string Price { get; }

        public float Distance { get; }

        public string Website { get; }

        public Bitmap RatingLookup(float rating)
        {
            Bitmap ratingAsImage = null;

            switch (rating)
            {
                case -1:
                    ratingAsImage = Properties.Resources.FFFFFF_0;
                    break;
                case 0:
                    ratingAsImage = Properties.Resources._0;
                    break;
                case 1:
                    ratingAsImage = Properties.Resources._1;
                    break;
                case 1.5f:
                    ratingAsImage = Properties.Resources._1_5;
                    break;
                case 2:
                    ratingAsImage = Properties.Resources._2;
                    break;
                case 2.5f:
                    ratingAsImage = Properties.Resources._2_5;
                    break;
                case 3:
                    ratingAsImage = Properties.Resources._3;
                    break;
                case 3.5f:
                    ratingAsImage = Properties.Resources._3_5;
                    break;
                case 4:
                    ratingAsImage = Properties.Resources._4;
                    break;
                case 4.5f:
                    ratingAsImage = Properties.Resources._4_5;
                    break;
                case 5:
                    ratingAsImage = Properties.Resources._5;
                    break;
            }

            return ratingAsImage ?? Properties.Resources._0;
        }
    }
}
