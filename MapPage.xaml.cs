using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            // Set HTML content with external resources and responsive design
            webView.Source = new HtmlWebViewSource
            {
                Html = @"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>CTAMA Headquarters Map</title>
  <link rel=""stylesheet"" href=""https://unpkg.com/leaflet/dist/leaflet.css"" />
  <style>
    body {
      margin: 0;
      padding: 0;
      overflow: hidden;
    }
    #map {
      height: 100vh; /* Full viewport height */
      width: 100vw;  /* Full viewport width */
    }
  </style>
</head>
<body>
  <div id=""map""></div>
  <script src=""https://unpkg.com/leaflet/dist/leaflet.js""></script>
  <script>
    // Initialize the map
    var map = L.map('map').setView([36.8005, 10.1815], 7); // Centered on CTAMA Headquarters

    // Add OpenStreetMap tile layer
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // Coordinates and addresses for the CTAMA locations
    var locations = [
      { coords: [36.8005, 10.1815], address: '100 Avenue de la Liberté, 1002 Tunis, Tunisie' },
      { coords: [36.8000, 10.1800], address: '38 Rue du 18 Janvier 1952, 1000 Tunis, Tunisie' },
      { coords: [36.8145, 10.1783], address: 'Rue du Lac Turkana, R6MP+HRF, Tunis, Tunisie' },
      { coords: [35.8256, 10.6360], address: '47 Avenue Habib Bourguiba, 4000 Sousse, Tunisie' },
      { coords: [35.8867, 10.5908], address: 'Immeuble Hssan n°321, Bureau n°1, Première étage GP1, à côté de la pharmacie de nuit, Hammam Sousse 4011, Tunisie' },
      { coords: [36.7314, 10.1972], address: 'Avenue Habib Bourguiba, 2000 Ben Arous, Tunisie' },
      { coords: [37.2749, 9.8739], address: 'Avenue Habib Bourguiba, 7000 Bizerte, Tunisie' },
      { coords: [33.8833, 10.0972], address: '47 Avenue Habib Bourguiba, 6000 Gabes, Tunisie' },
      { coords: [34.4254, 8.7803], address: 'Avenue Habib Bourguiba, 2100 Gafsa, Tunisie' },
      { coords: [36.5000, 8.7833], address: 'Avenue Habib Bourguiba, 8100 Jendouba, Tunisie' },
      { coords: [35.6787, 10.1014], address: 'Avenue Habib Bourguiba, 3100 Kairouan, Tunisie' },
      { coords: [35.1667, 8.8333], address: 'Avenue Habib Bourguiba, 1200 Kasserine, Tunisie' },
      { coords: [33.7072, 8.9742], address: 'Avenue Habib Bourguiba, 4200 Kebili, Tunisie' },
      { coords: [36.8233, 10.0894], address: 'Avenue Habib Bourguiba, 2010 La Manouba, Tunisie' },
      { coords: [36.1714, 8.7069], address: 'Avenue Habib Bourguiba, 7100 Le Kef, Tunisie' },
      { coords: [35.5047, 11.0621], address: '47 Avenue Habib Bourguiba, 5100 Mahdia, Tunisie' },
      { coords: [33.3533, 10.5075], address: '37 Avenue Habib Bourguiba, 4100 Médenine, Tunisie' },
      { coords: [35.7649, 10.8295], address: '47 Avenue Habib Bourguiba, 5000 Monastir, Tunisie' },
      { coords: [36.4572, 10.7381], address: '47 Avenue Habib Bourguiba, 8000 Nabeul, Tunisie' },
      { coords: [34.7402, 10.7603], address: '47 Avenue Habib Bourguiba, 3000 Sfax, Tunisie' }
    ];

    // Add markers to the map
    locations.forEach(function(location) {
      var marker = L.marker(location.coords).addTo(map);
      marker.bindPopup(location.address).openPopup();
    });
  </script>
</body>
</html>"
            };
        }

        // Event handlers for buttons
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

        private async void OnContactButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }

        private async void OnHelpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }

        private async void OnMapButtonClicked(object sender, EventArgs e)
        {
            // Handle Map button click if needed
        }
    }
}
