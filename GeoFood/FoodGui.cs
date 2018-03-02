using System.ComponentModel;
using System.Windows.Forms;
using GeoFood.Model;

namespace GeoFood
{
    public partial class FoodGui : Form
    {
        private readonly FoodContext _foodContext;
        private string _restaurantWebsite;
        public FoodGui()
        {
            InitializeComponent();
            _genPanel.Visible = false;
            _loadPanel.Visible = false;

            _foodContext = new FoodContext();

            _foodPrefDrop.Items.AddRange(FoodContext.FoodPreferences);

            _restPic.SizeMode = PictureBoxSizeMode.StretchImage;
            _foodPrefDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            _restRatePbox.BackgroundImageLayout = ImageLayout.Stretch;
            _restRatePbox.BorderStyle = BorderStyle.None;
            _restRatePbox.BackgroundImage = Properties.Resources.FFFFFF_0;

            HookEvents();

            #if DEBUG
            
            Properties.Settings.Default.Reset();

            #endif
        }

        #region Events

        // TODO add progress bar that hides after this returns true
        private void FoodContextOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == FoodContext.PropertyNameLoadFinished)
            {
                _loadPanel.Visible = false;
                _genPanel.Visible = true;
                DisplayNextRestaurant();
            }
        }

        private void _generateButton_Click(object sender, System.EventArgs e)
        {
            if (_foodPrefDrop.SelectedIndex > -1)
            {
                DisplayNextRestaurant();
            }
        }

        private void _backBtn_Click(object sender, System.EventArgs e)
        {
            _genPanel.Visible = false;
            _prefPanel.Visible = true;
        }

        private void _foodPrefDrop_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _prefPanel.Visible = false;
            _loadPanel.Visible = true;
            _foodContext.OnUserPreferenceChanged(_foodPrefDrop.SelectedIndex);
        }

        private void _restName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(_restaurantWebsite);
        }

        #endregion

        #region HelperFunctions

        private void HookEvents()
        {
            _foodContext.PropertyChanged += FoodContextOnPropertyChanged;
        }

        private void DisplayNextRestaurant()
        {
            

            Restaurant randomRestaurant = _foodContext.GetRandomRestaurant();//TODO ENCAPSULATE THIS^
            
            _restaurantWebsite = randomRestaurant.Website;
            _restPic.Load(randomRestaurant.Picture);
            _restName.Enabled = _restaurantWebsite != null;
            _restName.Text = randomRestaurant.Name;
            _restPrice.Text = randomRestaurant.Price;
            _restRatePbox.BackgroundImage = randomRestaurant.Rating;
            _restDistance.Text = randomRestaurant.Distance == 1.0 ? 
                randomRestaurant.Distance.ToString() + " mile" : 
                randomRestaurant.Distance.ToString() + " miles";
        }

        #endregion
    }
}
