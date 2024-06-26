using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GetStartedPage), typeof(GetStartedPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }
    }
}
