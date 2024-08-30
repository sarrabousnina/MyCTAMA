using System;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class PageLogin : ContentPage
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Get the username and password from the Entry fields
            string username = UsernameEntry.Text?.Trim(); 
            string password = PasswordEntry.Text?.Trim();

            // For debugging (optional)
            Console.WriteLine($"Username: {username}, Password: {password}");

            // Validate the credentials (example logic)
            if (username == "foulen" && password == "password")
            {
                // Store the username globally for access across the app
                App.CurrentUserName = username;

                // Fade out the login button
                await LoginButton.FadeTo(0, 500);
                LoginButton.IsVisible = false;

                // Show and fade in the success icon
                SuccessIcon.IsVisible = true;
                SuccessIcon.Opacity = 0; // Initial opacity
                await SuccessIcon.FadeTo(1, 500); // Fade in success icon

                // Wait before navigating to MenuPage
                await Task.Delay(1000);

                // Navigate to MenuPage and pass the username
                await Navigation.PushAsync(new MenuPage(username));
            }
            else
            {
                // Fade out the login button
                await LoginButton.FadeTo(0, 500);
                LoginButton.IsVisible = false;

                // Show and fade in the error icon and message
                ErrorIcon.IsVisible = true;
                ErrorMessage.IsVisible = true;
                ErrorIcon.Opacity = 0; // Initial opacity
                ErrorMessage.Opacity = 0; // Initial opacity
                await ErrorIcon.FadeTo(1, 500); // Fade in error icon
                await ErrorMessage.FadeTo(1, 500); // Fade in error message

                // Wait for 2 seconds before resetting
                await Task.Delay(2000);

                // Reset visibility and fade in the login button
                ErrorIcon.IsVisible = false;
                ErrorMessage.IsVisible = false;
                LoginButton.IsVisible = true;
                LoginButton.Opacity = 0; // Initial opacity
                await LoginButton.FadeTo(1, 500); // Fade in login button
            }
        }






        private async void OnCreateAccountTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }


        private void OnShowPasswordIconTapped(object sender, EventArgs e)
        {
            // Toggle password visibility
            bool isPasswordVisible = !PasswordEntry.IsPassword;
            PasswordEntry.IsPassword = isPasswordVisible;

            // Change icon based on visibility state
            ShowPasswordIcon.Text = isPasswordVisible ? "\uf070" : "\uf06e"; // Eye-slash for hidden, eye for visible
        }
    }
}
