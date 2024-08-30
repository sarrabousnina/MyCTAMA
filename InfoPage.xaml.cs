namespace MauiApp2
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        // Footer button click handlers
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

        private async void OnMapButtonClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new MapPage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception navigating to MapPage: {ex.Message}");
            }
        }
    }
}
