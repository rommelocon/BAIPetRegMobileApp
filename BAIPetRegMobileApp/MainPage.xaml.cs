using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp;
public partial class MainPage : ContentPage
{
    private readonly LoginPageViewModel viewModel;
    public MainPage()
    {
        InitializeComponent();
        viewModel = (LoginPageViewModel)BindingContext;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (viewModel != null)
        {
            viewModel.IsUserAuthenticated();
        }
    }

    private async void BtnGetStarted_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}