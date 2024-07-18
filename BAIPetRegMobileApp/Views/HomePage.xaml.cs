using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Maui.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
    private HomePageViewModel _viewModel;

    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.InitializeProfileAsync();
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private async void BtnRegisterPet_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PetRegisterPage));
    }

    private void MenuBtnClicked_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }

    private void PetinfoBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PetInformationPage));
    }

    private void HomepageBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
 
;    }
}