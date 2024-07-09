using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            // Initiate HomePage view
            var view = new HomePage();

            if (IsUserAuthenticated())
            {
                MainPage = new NavigationPage(view);
            }
            else
            {
                // Set the initial MainPage to AppShell
                MainPage = new AppShell();
            }
        }

        private bool IsUserAuthenticated()
        {
            var serializedLoginResponseInStorage = SecureStorage.Default.GetAsync("Authentication").Result;

            // Check if token exists and valid
            return !string.IsNullOrEmpty(serializedLoginResponseInStorage);

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}