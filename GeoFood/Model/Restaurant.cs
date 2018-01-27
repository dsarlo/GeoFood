using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFood.Model
{
    class Restaurant
    {
        private Image _picture;
        private string _name, _rating, _price;

        public Restaurant(Image picture, string name, string rating, string price)
        {
            _picture = picture;
            _name = name;
            _rating = rating;
            _price = price;
        }
    }
}
