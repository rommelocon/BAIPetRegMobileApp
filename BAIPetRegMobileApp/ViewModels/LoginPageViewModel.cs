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
        private string userName;
        [ObservableProperty]
        private bool isAuthenticated;

        private readonly ClientService clientService;
        private readonly HomePageViewModel homePageViewModel;

        public LoginPageViewModel(ClientService clientService, HomePageViewModel homePageViewModel)
        {
            this.clientService = clientService;
            this.homePageViewModel = homePageViewModel;
            RegisterModel = new RegisterModel();
            LoginModel = new LoginModel();
            IsAuthenticated = false;
        }

        [RelayCommand]
        private async Task Register()
        {
            await clientService.Register(RegisterModel);
        }

        [RelayCommand]
        private async Task Login()
        {
            await clientService.Login(LoginModel);
        }

        [RelayCommand]
        private async Task Logout()
        {
            Console.WriteLine("Logout command executed"); // Logging
            IsAuthenticated = false;
            LoginModel = new LoginModel();
            await clientService.Logout();
        }
    }
}