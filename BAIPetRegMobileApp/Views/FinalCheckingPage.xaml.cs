namespace BAIPetRegMobileApp.Views;

public partial class FinalCheckingPage : ContentPage
{
    public FinalCheckingPage()
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

    }

    private void BtnContinue_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomePage));
        ;
    }
}