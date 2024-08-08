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
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("final_checking", typeof(FinalCheckingPage));
            Routing.RegisterRoute("pet_registration", typeof(PetRegisterPage));
            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("profile", typeof(ProfilePage));
            Routing.RegisterRoute("pet_information", typeof(PetInformationPage));
            Routing.RegisterRoute("cat_breed", typeof(CatBreedPage));
            Routing.RegisterRoute("dog_breed", typeof(DogBreedPage));
            Routing.RegisterRoute("TOA", typeof(TOAPage));
            Routing.RegisterRoute("edit_profile", typeof(EditProfilePage));
        }

        [RelayCommand]
        private async Task Logout()
        {
            try
            {
                await clientService.Logout();
                Shell.Current.FlyoutIsPresented = false;
                await Shell.Current.GoToAsync("login");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Logout failed. Please try again.", "Ok");
            }
        }
    }
}