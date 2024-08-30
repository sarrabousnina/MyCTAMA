using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace MauiApp2.View.Details
{
    public partial class AssuranceAutomobilePage : ContentPage
    {
        private Dictionary<string, List<string>> carModels;

        public AssuranceAutomobilePage()
        {
            InitializeComponent();
            InitializeCarBrands();
            InitializeCarModels();
        }

        private void InitializeCarBrands()
        {
            var carBrands = new List<string>
            {
                "Toyota", "Honda", "Ford", "Kia", "Nissan",
                "Chevrolet", "BMW", "Mercedes", "Audi", "Volkswagen"
            };
            CarBrandPicker.ItemsSource = carBrands;
            CarBrandPicker.SelectedIndexChanged += OnCarBrandPickerSelectedIndexChanged;
            CarBrandPicker.SelectedIndexChanged += (s, e) =>
            {
                CarBrandPlaceholder.IsVisible = CarBrandPicker.SelectedIndex == -1;
            };
        }

        private void InitializeCarModels()
        {
            carModels = new Dictionary<string, List<string>>
            {
                // Existing brands and models
                { "Toyota", new List<string> { "Corolla", "Camry", "Prius", "RAV4", "Highlander" } },
                { "Honda", new List<string> { "Civic", "Accord", "CR-V", "Pilot", "Fit" } },
                { "Ford", new List<string> { "Focus", "Fusion", "Mustang", "Escape", "Explorer" } },
                { "Kia", new List<string> { "Rio", "Soul", "Sportage", "Sorento", "Telluride" } },
                { "Nissan", new List<string> { "Sentra", "Altima", "Maxima", "Rogue", "Murano" } },
                { "Chevrolet", new List<string> { "Spark", "Malibu", "Impala", "Equinox", "Traverse" } },
                { "BMW", new List<string> { "3 Series", "5 Series", "7 Series", "X3", "X5" } },
                { "Mercedes", new List<string> { "C-Class", "E-Class", "S-Class", "GLA", "GLC" } },
                { "Audi", new List<string> { "A3", "A4", "A6", "Q3", "Q5" } },
                { "Volkswagen", new List<string> { "Jetta", "Passat", "Golf", "Tiguan", "Atlas" } },

                // French Brands
                { "Renault", new List<string> { "Clio", "Mégane", "Captur", "Koleos", "Talisman" } },
                { "Peugeot", new List<string> { "208", "308", "3008", "5008", "Partner" } },
                { "Citroën", new List<string> { "C3", "C4", "C5", "C3 Aircross", "C5 Aircross" } },

                // Italian Brands
                { "Fiat", new List<string> { "Punto", "500", "Panda", "Tipo", "500L" } },
                { "Alfa Romeo", new List<string> { "Giulia", "Stelvio", "Giulietta", "4C", "159" } },
                { "Lancia", new List<string> { "Ypsilon", "Delta", "Fulvia", "Stratos", "Thema" } },

                // Chinese Brands
                { "Geely", new List<string> { "Emgrand", "Boyue", "Coolray", "Atlas", "Binrui" } },
                { "BYD", new List<string> { "Tang", "Han", "Song", "Qin", "Dolphin" } },
                { "Great Wall", new List<string> { "Haval H6", "Haval F7", "Haval H9", "Wingle 7", "Pao" } },
                { "Changan", new List<string> { "CS55", "CS75", "Eado", "Alsvin", "CS35" } },
                { "SAIC", new List<string> { "Roewe RX5", "Roewe i6", "MG Hector", "MG ZS", "MG Gloster" } },

                // Other Popular Brands
                { "Skoda", new List<string> { "Octavia", "Superb", "Fabia", "Kodiaq", "Karoq" } },
                { "Hyundai", new List<string> { "i10", "i20", "i30", "Elantra", "Tucson" } },
                { "Subaru", new List<string> { "Impreza", "Forester", "Outback", "Legacy", "XV" } },
                { "Mazda", new List<string> { "Mazda2", "Mazda3", "Mazda6", "CX-3", "CX-5" } },
                { "Land Rover", new List<string> { "Defender", "Discovery", "Range Rover", "Evoque", "Velar" } }
            };
        }




        private void OnCarBrandPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBrand = CarBrandPicker.SelectedItem as string;
            if (selectedBrand != null && carModels.ContainsKey(selectedBrand))
            {
                CarModelPicker.ItemsSource = carModels[selectedBrand];
                CarModelPlaceholder.IsVisible = true; // Reset the placeholder visibility
                CarModelPicker.SelectedIndex = -1; // Reset the selected index
            }
        }

        // Footer button event handlers
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
