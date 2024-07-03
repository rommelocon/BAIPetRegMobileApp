namespace BAIPetRegMobileApp.Views;

public partial class DataViewPage : ContentPage
{
	public DataViewPage()
	{
		InitializeComponent();
	}

    private void BtnPetListPage_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(PetListPage));
    }
}