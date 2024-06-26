using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the initial MainPage to AppShell
            MainPage = new AppShell();

            // Check if the user is already logged in
            CheckIfUserIsLoggedIn();
        }

        private async void CheckIfUserIsLoggedIn()
        {
            var hasAuth = await SecureStorage.GetAsync("hasAuth");
            if (hasAuth == "true")
            {
                // Navigate to HomePage if user is authenticated
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            else
            {
                // Navigate to GetStartedPage if user is not authenticated
                await Shell.Current.GoToAsync(nameof(GetStartedPage));
            }
        }
    }
}