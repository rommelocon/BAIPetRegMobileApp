using System.Security.Cryptography;
using System.Text;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp;


public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

        protected override bool OnBackButtonPressed()
        {
            Application.Current.Quit();
            return true;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (IsCredentialCorrect(UsernameEntry.Text, PasswordEntry.Text))
            {
                await SecureStorage.SetAsync("hasAuth", "true");
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            else
            {
                await DisplayAlert("Login failed", "Username or password is invalid", "Try again");
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;

            }
        }

    private async Task<bool> AuthenticateUser(string username, string password)
    {
        var client = new HttpClient();
        var loginData = new { Username = username, Password = password };
        var jsonContent = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://yourapiendpoint.com/api/auth/login", jsonContent);

        return response.IsSuccessStatusCode;
    }
}
