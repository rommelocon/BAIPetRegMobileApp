using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnGetStarted_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("login");
        }
    }
}