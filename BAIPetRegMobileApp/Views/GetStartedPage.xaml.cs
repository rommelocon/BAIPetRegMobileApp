namespace BAIPetRegMobileApp.Views;

public partial class GetStartedPage : ContentPage
{
    public GetStartedPage()
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;
    }

    private void BtnGetStarted_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }
}