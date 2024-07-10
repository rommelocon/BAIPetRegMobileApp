namespace BAIPetRegMobileApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}


    private void RegisterPetBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(PetRegisterPage));
    }
}