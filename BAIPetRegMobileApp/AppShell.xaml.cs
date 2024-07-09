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

        private async void BtnLogOut_Clicked(object sender, EventArgs e)
        {
            await SecureStorage.SetAsync("hasAuth", "false");
            await Shell.Current.GoToAsync(nameof(LoginPage));
            Shell.Current.FlyoutIsPresented = false;
        }

        private void BtnRegisterPet_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(PetRegisterPage));
        }

        private void RegisterPetPage_Clicked(object sender, EventArgs e)
        {

        }
    }
}
