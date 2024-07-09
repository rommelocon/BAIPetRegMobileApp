using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell(LoginPageViewModel loginPageViewModel)
        {
            InitializeComponent();
            BindingContext = loginPageViewModel;
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(FinalCheckingPage), typeof(FinalCheckingPage));
            Routing.RegisterRoute(nameof(PetRegisterPage), typeof(PetRegisterPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }

        private void ClostMenuButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }

        private void ProfilePageBtn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ProfilePage));
            Shell.Current.FlyoutIsPresented = false;
        }

        private void PetRegisterBtn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(PetRegisterPage));
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}