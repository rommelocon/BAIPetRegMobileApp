using Newtonsoft.Json;
using System.Text;

namespace BAIPetRegMobileApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnLoginButton_Clicked(object sender, EventArgs e)
	{
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (await AuthenticateUser(username, password))
        {
            // Navigate to the next page or display a success message
            await DisplayAlert("Success", "Login successful", "OK");
        }
        else
        {
            MessageLabel.Text = "Invalid username or password";
        }
    }

    private async Task<bool> AuthenticateUser(string username, string password)
    {
        // Call the API to authenticate the user
        // This is a simplified example. You should handle exceptions and responses properly.
        var httpClient = new HttpClient();
        var response = await httpClient.PostAsync("https://yourapiurl.com/api/login",
            new StringContent(JsonConvert.SerializeObject(new { username, password }), Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }
}
