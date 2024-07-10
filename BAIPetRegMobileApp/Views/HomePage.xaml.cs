using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel homePageViewModel)
    {
        InitializeComponent();
        BindingContext = homePageViewModel;
    }

    protected override bool OnBackButtonPressed()
    {
        //Application.Current.Quit();
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
}