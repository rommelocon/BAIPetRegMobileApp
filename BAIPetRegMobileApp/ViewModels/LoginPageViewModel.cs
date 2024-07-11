using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using System.Windows.Input;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private RegisterModel registerModel;
        [ObservableProperty]
        private LoginModel loginModel;

        [ObservableProperty]
        private bool isAuthenticated;

        private readonly ClientService clientService;

        public LoginPageViewModel(ClientService clientService)
        {
            this.clientService = clientService;
            RegisterModel = new RegisterModel();
            LoginModel = new LoginModel();
            IsAuthenticated = false;
            GetUserNameFromSecuredStorage();
        }

        [RelayCommand]
        private async Task Register()
        {
            await clientService.Register(RegisterModel);
        }

        [RelayCommand]
        private async Task Login()
        {
            Console.WriteLine("Login command executed"); // Logging
            await clientService.Login(LoginModel);
            GetUserNameFromSecuredStorage();
        }

        [RelayCommand]
        private async Task Logout()
        {
            Console.WriteLine("Logout command executed"); // Logging
            IsAuthenticated = false;
            await clientService.Logout();
        }

        public async void GetUserNameFromSecuredStorage()
        {
            var serializedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
            if (serializedLoginResponseInStorage != null)
            {
                IsAuthenticated = true;
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            IsAuthenticated = false;
        }
    }
}