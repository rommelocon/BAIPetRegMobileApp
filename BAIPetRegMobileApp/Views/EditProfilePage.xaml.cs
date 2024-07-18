using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage(EditProfilePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Refresh the ViewModel to clear any previous state
        if (BindingContext is EditProfilePageViewModel viewModel)
        {
            viewModel.Refresh(); // Add a method to your ViewModel to reset its state
        }
    }
}