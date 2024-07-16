namespace BAIPetRegMobileApp.Views;

public partial class DogBreedPage : ContentPage
{
	public DogBreedPage()
	{
        InitializeComponent();
    }

    private void MenuBtnClicked_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }

    private void HomepageBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
    }
}