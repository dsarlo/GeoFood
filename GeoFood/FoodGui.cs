using System.Windows.Forms;
using GeoFood.Model;

namespace GeoFood
{
    public partial class FoodGui : Form //★★★★☆
    {
        private readonly FoodContext _foodContext;

        public FoodGui()
        {
            InitializeComponent();

            _foodContext = new FoodContext();

            _restPic.SizeMode = PictureBoxSizeMode.StretchImage;
            _foodPrefDrop.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void _submitButton_Click(object sender, System.EventArgs e)
        {
            Restaurant randomRestaurant = _foodContext.GetRandomRestaurant();
            _restPic.Load(randomRestaurant.Picture);
            _restName.Text = randomRestaurant.Name;
            _restPrice.Text = randomRestaurant.Price;
            _restRate.Text = randomRestaurant.Rating.ToString();
        }

        private void _foodPrefDrop_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _foodContext.GatherListOfRestaurants(_foodPrefDrop.Items[_foodPrefDrop.SelectedIndex].ToString());
        }
    }
}
