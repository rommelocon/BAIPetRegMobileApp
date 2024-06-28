namespace BAIPetRegMobileApp.Views;

public partial class FinalCheckingPage : ContentPage
{
    public FinalCheckingPage()
    {
        InitializeComponent();
    }

    private void BtnContinue_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
;    }
}