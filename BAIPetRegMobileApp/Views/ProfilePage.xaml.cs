using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class ProfilePage : ContentPage
{
	private ProfilePageViewModel viewModel;
	private ClientService clientService;

	public ProfilePage(ClientService clientService,ProfilePageViewModel viewModel)
	{
		InitializeComponent();
		this.clientService = clientService;
		this.viewModel = viewModel;
		BindingContext = viewModel;
        Application.Current.UserAppTheme = AppTheme.Light;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var viewModel = new ProfilePageViewModel();
		var username = SecureStorage.Default.GetAsync("Authentication").Result;
		var profileData = await clientService.GetProfilePageViewModel(username);
	}
}