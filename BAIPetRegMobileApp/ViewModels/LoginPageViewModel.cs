using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private LoginModel loginModel;

        private readonly ClientService clientService;

        public LoginPageViewModel(ClientService clientService)
        {
            this.clientService = clientService;
            LoginModel = new LoginModel();
        }

        [RelayCommand]
        private async Task Login()
        {
            await clientService.Login(LoginModel);
        }

        [RelayCommand]
        private async Task Logout()
        {
            Console.WriteLine("Logout Command Call");
            await clientService.Logout();
        }
    }
}