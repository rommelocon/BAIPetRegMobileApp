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

    private async void BtnGetStarted_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}