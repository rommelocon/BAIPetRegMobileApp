using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly HomePageViewModel viewModel;

        public HomePage(HomePageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.InitializeProfileAsync();
            await viewModel.RefreshPetRegistrationsAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
