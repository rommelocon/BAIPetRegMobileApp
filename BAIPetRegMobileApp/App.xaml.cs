using BAIPetRegMobileApp.Models;

namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {
        public static User user;
        public App()
        {
            InitializeComponent();

            // Set the initial MainPage to AppShell
            MainPage = new AppShell();
        }
    }
}