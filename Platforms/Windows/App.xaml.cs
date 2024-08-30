using Microsoft.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace MauiApp2.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object. This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            var currentWindow = Application.Windows.FirstOrDefault();

            if (currentWindow != null)
            {
                // Get the native window handle
                var nativeWindow = currentWindow.Handler.PlatformView as Microsoft.UI.Xaml.Window;

                if (nativeWindow != null)
                {
                    // Retrieve the AppWindow for the native window
                    var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                    var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
                    var appWindow = AppWindow.GetFromWindowId(windowId);

                    // Set the desired phone screen size
                    appWindow.Resize(new SizeInt32(400, 667));
                }
            }
        }
    }
}
