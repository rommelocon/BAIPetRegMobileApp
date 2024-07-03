using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(GetStartedPage), typeof(GetStartedPage));
            Routing.RegisterRoute(nameof(FinalCheckingPage), typeof(FinalCheckingPage));
            Routing.RegisterRoute(nameof(PetRegisterPage), typeof(PetRegisterPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(DataViewPage), typeof(DataViewPage));
            Routing.RegisterRoute(nameof(PetListPage), typeof(PetListPage));    
        }
    }
}
