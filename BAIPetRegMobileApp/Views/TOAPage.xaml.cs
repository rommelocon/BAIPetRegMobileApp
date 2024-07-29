namespace BAIPetRegMobileApp.Views;

public partial class TOAPage : ContentPage
{
    public TOAPage()
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

    private void OnAcceptCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            AcceptButton.BackgroundColor = Color.FromArgb("#2E8B26");
            AcceptButton.IsEnabled = true;
        }
        else
        {
            AcceptButton.BackgroundColor = Color.FromArgb("#C2C2C2");
            AcceptButton.IsEnabled = false;
        }
    }

    private async void OnAcceptButtonClicked(object sender, EventArgs e)
    {
        if (AcceptCheckBox.IsChecked)
        {
            // Navigate to another page
            await Shell.Current.GoToAsync(nameof(PetRegisterPage));
        }
    }
}