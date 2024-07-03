namespace BAIPetRegMobileApp.Views;

public partial class PetListPage : ContentPage
{
	public PetListPage()
	{
		InitializeComponent();
	}

    private void BtnPet1_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(DataViewPage));
    }

    private void BtnPet2_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DataViewPage));
    }

    private void BtnPet3_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DataViewPage));
    }

    private void BtnPet4_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DataViewPage));
    }

    private void BtnPet5_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DataViewPage));
    }

    private void BtnPet6_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DataViewPage));
    }

    private void BtnHomePage_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
    }
}