using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
    private HomePageViewModel viewModel;

    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.LoadProfileCommand.ExecuteAsync(null); ;
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