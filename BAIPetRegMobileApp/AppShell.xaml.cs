using BAIPetRegMobileApp.Views.Dashboard;

namespace BAIPetRegMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        }
    }
}
