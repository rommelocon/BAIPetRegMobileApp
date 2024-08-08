namespace BAIPetRegMobileApp.Views;

public partial class TOAPage : ContentPage
{
    public TOAPage()
    {
        InitializeComponent();
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
            await Shell.Current.GoToAsync("pet_registration");
        }
    }
}