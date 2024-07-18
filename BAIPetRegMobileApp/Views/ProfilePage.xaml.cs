using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class ProfilePage : ContentPage
{
	private ProfilePageViewModel viewModel;

	public ProfilePage(ProfilePageViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		BindingContext = viewModel;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
        // Load the profile when the page appears
        await viewModel.InitializeProfileAsync();
    }

    private void EditProfile_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(EditProfilePage));
    }
}