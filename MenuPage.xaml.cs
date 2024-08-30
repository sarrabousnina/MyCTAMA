using MauiApp2.View.Details;

namespace MauiApp2
{
    public partial class MenuPage : ContentPage
    {
        private TimeSpan _carouselInterval = TimeSpan.FromSeconds(3); // Interval of 3 seconds
        private List<string> _imageSources;
        private bool _isMenuOpen = false;
        private string _username;
        public List<string> ImageSources
        {
            get => _imageSources;
            set
            {
                _imageSources = value;
                OnPropertyChanged(nameof(ImageSources));
            }
        }

        public MenuPage(string username)
        {
            InitializeComponent();
            SetupCarousel();
            StartCarouselTimer();
            StartPulseAnimation();
            _username = username;

            // Set the welcome text with the username
            WelcomeLabel.Text = $"Bienvenue, {_username}";
        }

        private void SetupCarousel()
        {
            // Initialize the image sources
            ImageSources = new List<string>
        {

            "pub3.jpg",
            "pub4.jpg",
            "pub5.jpg",
            "pub.jpeg",
            "pub2.jpeg"
        };

            // Set the BindingContext for data binding
            BindingContext = this;
        }

        private void StartCarouselTimer()
        {
            Device.StartTimer(_carouselInterval, () =>
            {
                if (carouselView != null && carouselView.ItemsSource is List<string> itemsSource)
                {
                    int itemCount = itemsSource.Count;
                    if (itemCount > 0)
                    {
                        // Move to the next item in the carousel
                        int currentPosition = carouselView.Position;
                        int nextPosition = (currentPosition + 1) % itemCount;
                        carouselView.Position = nextPosition;

                        // Optionally update the indicator view position
                        if (indicatorView != null)
                        {
                            indicatorView.Position = nextPosition;
                        }
                    }
                }

                // Return true to keep the timer running
                return true;
            });
        }

        private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
        {
            if (indicatorView != null)
            {
                // Update the IndicatorView's position
                indicatorView.Position = e.CurrentPosition;
            }
        }

        // Shortened event handlers for buttons
        /*private void LoadHtmlContent()
        {
            // Get paths for HTML and CSS files
            var htmlPath = Path.Combine(FileSystem.AppDataDirectory, "Html", "menub.html");
            var cssPath = Path.Combine(FileSystem.AppDataDirectory, "Css", "menub.css");

            // Load HTML and CSS content
            var htmlContent = File.ReadAllText(htmlPath);
            var cssContent = File.ReadAllText(cssPath);

            // Inject CSS into HTML
            var htmlWithCss = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>{cssContent}</style>
                </head>
                <body>
                    {htmlContent}
                </body>
                </html>";

            // Set the HTML content in the WebView
            MenuWebView.Source = new HtmlWebViewSource
            {
                Html = htmlWithCss
            };
        }*/
        private async void OnCarQuoteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssuranceAutomobilePage());
        }
        private async void OnAgriQuoteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgriculteursPage());
        }
        private async void OnHealthQuoteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssuranceViePage());
        }
        private async void OnHabButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssuranceMultirisquesHabitationPage());
        }

        private async void OnFacebookButtonClicked(object sender, EventArgs e)
        {
            try
            {
                await Launcher.OpenAsync("https://www.facebook.com/lactama1912");
            }
            catch (Exception ex)
            {
                // Handle the exception
                System.Diagnostics.Debug.WriteLine($"Exception opening Facebook: {ex.Message}");
            }
        }
        private void StartPulseAnimation()
        {
            // Ensure the button is visible and scale is initially 1
            FAQButton.Scale = 1;

            // Create a scale animation that pulses the ImageButton
            var scaleUpAnimation = new Animation(v => FAQButton.Scale = v, 1, 1.2);
            var scaleDownAnimation = new Animation(v => FAQButton.Scale = v, 1.2, 1);

            // Combine animations
            var animation = new Animation();
            animation.Add(0, 0.5, scaleUpAnimation);
            animation.Add(0.5, 1, scaleDownAnimation);

            // Commit the animation with a slower duration
            animation.Commit(this, "PulseAnimation", length: 2000, repeat: () => true, easing: Easing.Linear);
        }
        private async void OnFAQButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FAQPage());
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
        //end footer 

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Ensure that the animation runs when the page appears
            // Reset opacity and positions
            ResetAnimations();

            // Animate Icons and Texts
            await AnimateIconsAndTexts();
        }

        private void ResetAnimations()
        {
            // Reset opacity and positions to initial state
            HomeIcon.Opacity = 0;
            HomeText.Opacity = 0;
            ContactIcon.Opacity = 0;
            ContactText.Opacity = 0;
            HelpIcon.Opacity = 0;
            HelpText.Opacity = 0;
            MapIcon.Opacity = 0;
            MapText.Opacity = 0;

            // Optionally reset position if needed
            // HomeIcon.TranslationX = 0;
            // HomeText.TranslationX = 0;
            // Similarly for other elements
        }

        private async Task AnimateIconsAndTexts()
        {
            // Faster animation for Home Icon and Text
            await HomeIcon.FadeTo(1, 300); // Duration: 300ms
            await HomeText.FadeTo(1, 300); // Duration: 300ms
            await Task.Delay(100); // Delay between animations

            // Faster animation for Contact Icon and Text
            await ContactIcon.FadeTo(1, 300); // Duration: 300ms
            await ContactText.FadeTo(1, 300); // Duration: 300ms
            await Task.Delay(100);

            // Faster animation for Help Icon and Text
            await HelpIcon.FadeTo(1, 300); // Duration: 300ms
            await HelpText.FadeTo(1, 300); // Duration: 300ms
            await Task.Delay(100);

            // Faster animation for Map Icon and Text
            await MapIcon.FadeTo(1, 300); // Duration: 300ms
            await MapText.FadeTo(1, 300); // Duration: 300ms
        }

        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            if (_isMenuOpen)
            {
                // Close Menu with faster animation
                await Task.WhenAll(
                    MenuOverlay.FadeTo(0, 200), // Duration: 200ms
                    MenuOverlay.TranslateTo(0, 0, 200), // Duration: 200ms
                    MenuPanel.TranslateTo(Width, 0, 200, Easing.CubicIn), // Move to right, Duration: 200ms
                    MenuPanel.FadeTo(0, 200) // Duration: 200ms
                );
                MenuOverlay.IsVisible = false;
                MenuPanel.IsVisible = false;

                // Optionally reset animations for icons/texts if needed
                ResetAnimations();
            }
            else
            {
                // Open Menu with faster animation
                MenuOverlay.IsVisible = true;
                MenuPanel.IsVisible = true;

                await Task.WhenAll(
                    MenuOverlay.FadeTo(0.8, 200), // Duration: 200ms
                    MenuOverlay.TranslateTo(0, 0, 200), // Duration: 200ms
                    MenuPanel.TranslateTo(0, 0, 200, Easing.CubicOut), // Move from right, Duration: 200ms
                    MenuPanel.FadeTo(1, 200) // Duration: 200ms
                );

                // Animate Icons and Texts
                await AnimateIconsAndTexts();
            }

            _isMenuOpen = !_isMenuOpen;
        }

    }
}
