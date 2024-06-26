using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void BtnRegisterPet_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(RegisterPage));
    }

    private void BtnLogout_Clicked(object sender, EventArgs e)
    {

    }
}