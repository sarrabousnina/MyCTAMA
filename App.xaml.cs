using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class App : Application
    {
        // Static property to store the current username globally
        public static string CurrentUserName { get; set; }

        public App()
        {
            InitializeComponent();

            // Set the MainPage to a NavigationPage with the main page of your application
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
