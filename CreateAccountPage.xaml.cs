using System;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }
        private async void OnLoginTapped(object sender, EventArgs e)
        {
            // Navigate to the login page or perform any other action
            await Navigation.PushAsync(new PageLogin());
        }
        private void OnShowPasswordIconTapped(object sender, EventArgs e)
        {
            bool isPasswordVisible = !PasswordEntry.IsPassword;
            PasswordEntry.IsPassword = isPasswordVisible;
            ShowPasswordIcon.Text = isPasswordVisible ? "\uf070" : "\uf06e"; // Eye-slash for hidden, eye for visible
        }


        private async void OnCreateAccountButtonClicked(object sender, EventArgs e)
        {
            // Example validation logic (you can replace this with actual validation)
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            // Simulate successful account creation
            // (Replace this with actual account creation logic)

            // Fade out the button
            await CreateButton.FadeTo(0, 500); // Fade out in 0.5 seconds

            // Show the tick icon
            SuccessTickIcon.IsVisible = true;
            SuccessTickIcon.Opacity = 0; // Start with invisible
            await SuccessTickIcon.FadeTo(1, 500); // Fade in in 0.5 seconds

            // Wait for a few seconds before navigating
            await Task.Delay(1500); // Show for 2 seconds

            // Navigate to PageLogin
            await Navigation.PushAsync(new PageLogin());
        }


    }
}
