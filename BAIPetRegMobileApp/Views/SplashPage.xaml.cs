using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views
{
    public partial class SplashPage : ContentPage
    {
        private readonly ClientService clientService;

        public SplashPage(ClientService clientService)
        {
            InitializeComponent();
            this.clientService = clientService;
        }
    }

}