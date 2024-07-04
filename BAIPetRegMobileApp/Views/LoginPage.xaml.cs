using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ClickableLabel_Tapped(object sender, TappedEventArgs e)
        {
            string url = "https://www.bai.gov.ph/Admin/Account/ClientRegistration";

            await Launcher.OpenAsync(url);
        }

        private async void ForgotPasswordLabel_Tapped(object sender, TappedEventArgs e)
        {
            string url = "https://www.bai.gov.ph/Admin/Account/Forgot";

            await Launcher.OpenAsync(url);
        }
    }
}