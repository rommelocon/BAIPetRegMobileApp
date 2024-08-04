using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views
{
    public partial class PetRegisterPage : ContentPage
    {
        private readonly PetRegisterPageViewModel viewModel;
        public PetRegisterPage(PetRegisterPageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = viewModel;
        }

        private async Task PetRegistrationSubmitAsync()
        {
            await viewModel.PetRegistrationSubmit();
        }
    }
}