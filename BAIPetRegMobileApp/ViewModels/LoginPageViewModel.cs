using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private RegisterModel registerModel;
        [ObservableProperty]
        private LoginModel loginModel;

        [ObservableProperty]
        private string? userName;
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
            SecureStorage.Default.Remove("Authentication");
            IsAuthenticated = false;
            UserName = "Guest";
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        private async void GetUserNameFromSecuredStorage()
        {
            if (!string.IsNullOrEmpty(UserName) && UserName! != "Guest")
            {
                IsAuthenticated = true;
                return;
            }
            var serializedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
            if (serializedLoginResponseInStorage != null)
            {
                UserName = JsonSerializer.Deserialize<LoginResponse>(serializedLoginResponseInStorage)!.UserName!;
                IsAuthenticated = true;
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            UserName = "Guest";
            IsAuthenticated = false;
        }

        public async void IsUserAuthenticated()
        {
            var serializedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
            if (serializedLoginResponseInStorage != null)
            {
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
        }
    }
}