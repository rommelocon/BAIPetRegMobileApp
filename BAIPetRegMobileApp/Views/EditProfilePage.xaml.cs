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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is EditProfilePageViewModel viewModel)
        {
            await viewModel.InitializeAsync();
        }
    }
}