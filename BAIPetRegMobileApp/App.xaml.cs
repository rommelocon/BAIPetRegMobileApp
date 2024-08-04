using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {
        private readonly ClientService _clientService;
        private readonly LoginPageViewModel _loginPageViewModel;
        public App(ClientService clientService, LoginPageViewModel loginPageViewModel)
        {
            InitializeComponent();
            _clientService = clientService;
            _loginPageViewModel = loginPageViewModel;
            bool isAuthenticated = CheckIfUserIsAuthenticated();

            if (!isAuthenticated)
                MainPage = new LoginPage(_loginPageViewModel);
            else
                MainPage = new AppShell(_clientService);
        }

        private bool CheckIfUserIsAuthenticated()
        {
            var token = SecureStorage.GetAsync("Authentication").Result;
            return !string.IsNullOrEmpty(token);
        }
    }
}