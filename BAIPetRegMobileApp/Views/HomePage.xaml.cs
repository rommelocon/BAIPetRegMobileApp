using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Maui.Views;

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
        await viewModel.InitializeProfileAsync();
    }

    protected override bool OnBackButtonPressed()
    {
        //Application.Current.Quit();
        return true;
    }

    private void BtnRegisterPet_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync(nameof(PetRegisterPage));
        Shell.Current.GoToAsync(nameof(TOAPage));
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

        ;
    }


}