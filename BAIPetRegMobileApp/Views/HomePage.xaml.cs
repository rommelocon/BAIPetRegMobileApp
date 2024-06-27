using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
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

    private async void BtnLogout_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.SetAsync("hasAuth", "false");
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}