using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace BAIPetRegMobileApp.Services;
public class ClientService
{
    private readonly IHttpClientFactory httpClientFactory;

    public ClientService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task Register(RegisterModel model)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/register", model);
        if (result.IsSuccessStatusCode)
        {
            await Shell.Current.DisplayAlert("Alert", "Successfully Registered.", "Ok");
        }
        await Shell.Current.DisplayAlert("Alert", result.ReasonPhrase, "Ok");
    }

    public async Task Login(LoginModel model)
    {
        Console.WriteLine("Login Method Called");// Logginf
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/login", model);
        if (result.IsSuccessStatusCode)
        {
            var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
            if (response is not null)
            {
                var serializedResponse = JsonSerializer.Serialize(new LoginResponse() 
                    { 
                        AccessToken = response.AccessToken, 
                        RefreshToken = response.RefreshToken, 
                        UserName = model.Email 
                    });

                await SecureStorage.Default.SetAsync("Authentication", serializedResponse);

                // Navigate to the main page
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Login failed. Please try again.", "Ok");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Alert", "Login failed. Please try again.", "Ok");
        }
    }
}