namespace MauiApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PageLogin),typeof(PageLogin));

          /*  Routing.RegisterRoute(
                nameof(DevisTypesPage), 
                typeof(DevisTypesPage));*/
        }
    }
}
