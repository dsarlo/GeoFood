using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using GeoFood.Model;

namespace GeoFood
{
    public partial class FoodGui : Form
    {
        private readonly FoodContext _foodContext;

        private const string PreferenceNotChosenText = "You must select a preference before activating the randomizer!";

        public FoodGui()
        {
            InitializeComponent();

            _foodContext = new FoodContext();

            _foodPrefDrop.Items.AddRange(FoodContext.FoodPreferences);

            _restPic.SizeMode = PictureBoxSizeMode.StretchImage;
            _foodPrefDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            _restRatePbox.BackgroundImageLayout = ImageLayout.Stretch;
            _restRatePbox.BorderStyle = BorderStyle.None;
            _restRatePbox.BackgroundImage = Properties.Resources.FFFFFF_0;

            HookEvents();
            HideForm();

            #if DEBUG
            
            Properties.Settings.Default.Reset();

            #endif
        }

        #region Events

        private void OnPreloadFinished(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == FoodContext.PropertyNamePreloadFinished)
            {
                ShowForm();
            }
        }

        private void _submitButton_Click(object sender, System.EventArgs e)
        {
            if (_foodPrefDrop.SelectedIndex > -1)
            {
                Restaurant randomRestaurant = _foodContext.GetRandomRestaurant();
                _restPic.Load(randomRestaurant.Picture);//TODO Optimize this. Perhaps convert it to a bitmap on preload?
                _restName.Text = randomRestaurant.Name;
                _restPrice.Text = randomRestaurant.Price;
                _restRatePbox.BackgroundImage = randomRestaurant.Rating;
            }
            else
            {
                MessageBox.Show(PreferenceNotChosenText);//TODO make this messagebox look nicer!
            }
        }

        private void _foodPrefDrop_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _foodContext.ChangeUserPreference(_foodPrefDrop.SelectedIndex);
        }

        #endregion

        #region HelperFunctions

        private void HookEvents()
        {
            _foodContext.PropertyChanged += OnPreloadFinished;
        }

        private void HideForm()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void ShowForm()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        #endregion
    }
}
