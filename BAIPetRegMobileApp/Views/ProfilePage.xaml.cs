using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class ProfilePage : ContentPage
{
    private readonly ProfilePageViewModel _viewModel;

	public ProfilePage(ProfilePageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
        Application.Current.UserAppTheme = AppTheme.Light;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
        // Load the profile when the page appears
        await viewModel.InitializeProfile();
    }
}