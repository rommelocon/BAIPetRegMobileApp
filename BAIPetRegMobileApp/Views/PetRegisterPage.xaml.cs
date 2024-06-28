namespace BAIPetRegMobileApp.Views;

public partial class PetRegisterPage : ContentPage
{
    public PetRegisterPage()
    {
        InitializeComponent();

    }

    private void Picker_Focused(object sender, FocusEventArgs e)
    {

    }

    private void BtnSubmit_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(FinalCheckingPage));
    }
}