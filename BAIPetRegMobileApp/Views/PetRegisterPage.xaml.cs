using AndroidX.Lifecycle;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
    private readonly PetRegisterPageViewModel petRegisterPageViewModel;
    public PetRegisterPage(PetRegisterPageViewModel petRegisterPageViewModel)
    {
        InitializeComponent();
        this.petRegisterPageViewModel = petRegisterPageViewModel;
        BindingContext = petRegisterPageViewModel;
    }

    private async Task PetRegistrationSubmitAsync()
    {
        await petRegisterPageViewModel.PetRegistrationSubmit();
    }
}
