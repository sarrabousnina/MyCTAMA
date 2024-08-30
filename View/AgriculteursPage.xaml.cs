using Microsoft.Maui.Controls;

namespace MauiApp2.View.Details
{
    public partial class AgriculteursPage : ContentPage
    {
        public AgriculteursPage()
        {
            InitializeComponent();
        }
        //footer functions
        private async void OnHomeButtonClicked(object sender, EventArgs e)
        {
            string username = App.CurrentUserName; // Get the dynamically stored username

            if (!string.IsNullOrEmpty(username))
            {
                await Navigation.PushAsync(new MenuPage(username));
            }
            else
            {
                // Handle the case where the username is not set, if needed
            }
        }

        private async void OnHelpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }
        private async void OnContactButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }

        private async void OnInfoButtonClicked(object sender, EventArgs e)
        {
            // Correct way to navigate to InfoPage
            await Navigation.PushAsync(new InfoPage());
        }

        private async void OnMapButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Navigate to the Map page
                await Navigation.PushAsync(new MapPage());
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                System.Diagnostics.Debug.WriteLine($"Exception navigating to MapPage: {ex.Message}");
            }
        }


    }
}