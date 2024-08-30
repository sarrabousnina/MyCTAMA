using System;
using Microsoft.Maui.Controls;
using MauiApp2.View.Details;

namespace MauiApp2;

    public partial class DemanderUnDevisPage : ContentPage
    {
        public DemanderUnDevisPage()
        {
            InitializeComponent();
        }

        private async void OnAssuranceAutomobileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssuranceAutomobilePage());
        }

        private async void OnAgriculteursClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgriculteursPage());
        }

        private async void OnAssuranceMultirisquesHabitationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssuranceMultirisquesHabitationPage());
        }

        private async void OnAssuranceVieClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssuranceViePage());
        }
    }