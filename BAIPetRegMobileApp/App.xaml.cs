using BAIPetRegMobileApp.Services;

namespace BAIPetRegMobileApp
{
    public partial class App : Application
    {
        public App(ClientService clientService)
        {
            InitializeComponent();
            MainPage = new AppShell(clientService);
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}