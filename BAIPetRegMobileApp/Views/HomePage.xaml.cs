using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Handle navigation parameters
        MessagingCenter.Subscribe<HomePageViewModel, string>(this, "UserName", (sender, arg) =>
        {
            UsernameLabel.Text = arg;
        });
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