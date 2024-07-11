using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _viewModel;
    private ClientService _clientService;
 
    public HomePage(HomePageViewModel viewModel, ClientService clientService)
    {
        InitializeComponent();
        this._clientService = clientService;
        _viewModel = new HomePageViewModel(clientService);
        BindingContext = _viewModel;
    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();

    //    await _viewModel.LoadUserInfo();
    //}

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