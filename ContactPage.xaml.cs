using Microsoft.Maui.Controls;
using System;

namespace MauiApp2
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            string nom = NomEntry.Text;
            string prenom = PrenomEntry.Text;
            string email = EmailEntry.Text;
            string phone = PhoneEntry.Text;
            string entreprise = EntrepriseEntry.Text;
            string departement = DepartementPicker.SelectedItem?.ToString();
            string objet = ObjetEntry.Text;
            string message = MessageEditor.Text;

            // Reset error labels
            NomErrorLabel.IsVisible = false;
            PrenomErrorLabel.IsVisible = false;
            EmailErrorLabel.IsVisible = false;
            PhoneErrorLabel.IsVisible = false;
            ObjetErrorLabel.IsVisible = false;
            MessageErrorLabel.IsVisible = false;

            bool isValid = true;

            if (string.IsNullOrEmpty(nom))
            {
                NomErrorLabel.IsVisible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(prenom))
            {
                PrenomErrorLabel.IsVisible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(email))
            {
                EmailErrorLabel.IsVisible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(phone))
            {
                PhoneErrorLabel.IsVisible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(objet))
            {
                ObjetErrorLabel.IsVisible = true;
                isValid = false;
            }

            if (string.IsNullOrEmpty(message))
            {
                MessageErrorLabel.IsVisible = true;
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            // For this example, we just show a confirmation message
            ResultLabel.Text = "Merci de nous avoir contactés!";
            ResultLabel.IsVisible = true;

            // Clear the form fields
            NomEntry.Text = string.Empty;
            PrenomEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            EntrepriseEntry.Text = string.Empty;
            DepartementPicker.SelectedIndex = -1;
            ObjetEntry.Text = string.Empty;
            MessageEditor.Text = string.Empty;
        }

        //begin footer
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
