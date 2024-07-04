namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the initial MainPage to AppShell
            MainPage = new AppShell();
        }
    }
}