using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
    private bool _disposed = false;
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}

    protected override bool OnBackButtonPressed()
    {
        //Application.Current.Quit();
        return true;
    }

    private void BtnRegisterPet_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PetRegisterPage));
    }
}