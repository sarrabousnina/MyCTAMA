using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Define the absolute path to the HTML file
            string htmlFilePath = @"C:\Users\user\Desktop\MauiApp2-master\wwwroot\index.html";

            // Debug output for the file path
            Console.WriteLine($"HTML Source Path: {htmlFilePath}");

            // Load the HTML file into the WebView
            if (File.Exists(htmlFilePath))
            {
                MyWebView.Source = new UrlWebViewSource
                {
                    Url = $"file:///{htmlFilePath.Replace('\\', '/')}"
                };
            }
            else
            {
                MyWebView.Source = new HtmlWebViewSource
                {
                    Html = "<h1>Error: File Not Found</h1>"
                };
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Wait for 6 seconds
            await Task.Delay(6000);

            // Navigate to LoginPage
            await Navigation.PushAsync(new PageLogin());
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageLogin());
        }
    }
}
