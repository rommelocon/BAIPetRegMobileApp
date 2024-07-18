using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class EditProfilePage : ContentPage
{
    private readonly EditProfilePageViewModel viewModel;
	public EditProfilePage(EditProfilePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Refresh the ViewModel to clear any previous state
        if (BindingContext is EditProfilePageViewModel viewModel)
        {
        }
    }
}