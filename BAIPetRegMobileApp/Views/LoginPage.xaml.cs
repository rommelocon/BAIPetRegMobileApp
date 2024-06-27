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

        var loginResult = await AuthenticateUser(username, password);

        if (loginResult)
        {
            await DisplayAlert("Success", "Login successful!", "OK");
            // Navigate to the next page or main application page
        }
        else
        {
            ResultLabel.Text = "Login failed. Please try again.";
            ResultLabel.IsVisible = true;
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
