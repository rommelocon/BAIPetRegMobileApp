using BAIPetRegMobileApp.Models.User;
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
            if (Application.Current != null)
            {
                Application.Current.MainPage = new AppShell(clientService);
            }
            else
            {
                throw new InvalidOperationException("Application.Current is null. Unable to set MainPage.");
            }
        }
    }
}