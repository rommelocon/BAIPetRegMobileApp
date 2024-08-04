using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views
{
    public partial class PetInformationPage : ContentPage
    {
        private readonly PetInformationPageViewModel viewModel;
        public PetInformationPage(PetInformationPageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = viewModel;
        }
    }
}

