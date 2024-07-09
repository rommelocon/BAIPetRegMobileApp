using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {
        public App(LoginPageViewModel loginPageViewModel)
        {
            InitializeComponent();
            MainPage = new AppShell(loginPageViewModel: loginPageViewModel);
        }
        private bool IsUserAuthenticated()
        {
            var serializedLoginResponseInStorage = SecureStorage.Default.GetAsync("Authentication").Result;

            // Check if token exists and valid
            return !string.IsNullOrEmpty(serializedLoginResponseInStorage);
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}