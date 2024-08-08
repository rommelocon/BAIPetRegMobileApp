using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.Input;

namespace BAIPetRegMobileApp
{
    public partial class AppShell : Shell
    {
        private readonly ClientService clientService;
        public AppShell(ClientService clientService)
        {
            InitializeComponent();
            RegisterRoutes();
            this.clientService = clientService;
            BindingContext = this;
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(FinalCheckingPage), typeof(FinalCheckingPage));
            Routing.RegisterRoute(nameof(PetRegisterPage), typeof(PetRegisterPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(PetInformationPage), typeof(PetInformationPage));
            Routing.RegisterRoute(nameof(CatBreed), typeof(CatBreed));
            Routing.RegisterRoute(nameof(DogBreed), typeof(DogBreed));
            Routing.RegisterRoute(nameof(TOAPage), typeof(TOAPage));
            Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));
            Routing.RegisterRoute(nameof(SplashPage), typeof(SplashPage));
        }

        [RelayCommand]
        private async Task Logout()
        {
            try
            {
                await clientService.Logout();
                Shell.Current.FlyoutIsPresented = false;
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Logout failed. Please try again.", "Ok");
            }
        }
    }
}