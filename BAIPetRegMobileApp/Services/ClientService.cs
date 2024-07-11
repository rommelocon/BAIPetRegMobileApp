using BAIPetRegMobileApp.Models;
using System.Net.Http.Headers;
using System.Net.Http;
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
        Console.WriteLine("Login Method Called"); // Logging
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/Account/login", model);

        if (result.IsSuccessStatusCode)
        {
            var responseContent = await result.Content.ReadFromJsonAsync<LoginResponse>();

            if (responseContent is not null)
            {
                var serializedResponse = JsonSerializer.Serialize(
                    new LoginResponse()
                    {
                        TokenType = responseContent.TokenType,
                        AccessToken = responseContent.AccessToken,
                        ExpiresIn = responseContent.ExpiresIn,
                        RefreshToken = responseContent.RefreshToken,
                    });
                await SecureStorage.SetAsync("Authentication", serializedResponse);

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

    public async Task Logout()
    {
        Console.WriteLine("Logout Method Called"); // Logging
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsync("/Account/logout", null);
        SecureStorage.Default.Remove("Authentication");

        // Navigate to the login page
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    public async Task<UserModel> GetUser()
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");

        try
        {
            var tokenJson = await SecureStorage.GetAsync("Authentication");

            if (string.IsNullOrEmpty(tokenJson))
            {
                Console.WriteLine("Authentication token is null or empty.");
                return null;
            }

            // Deserialize the token JSON to extract the AccessToken
            var tokenData = JsonSerializer.Deserialize<LoginResponse>(tokenJson);

            if (tokenData == null || string.IsNullOrEmpty(tokenData.AccessToken))
            {
                Console.WriteLine("Access token is null or empty.");
                return null;
            }

            // Set the authorization header with the Bearer token
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenData.AccessToken);

            var result = await httpClient.GetAsync("/Account/user"); // Replace with your actual endpoint URL

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var userInfo = JsonSerializer.Deserialize<UserModel>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return userInfo;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve user information. Status code: {result.StatusCode}. Reason: {result.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }

        return null;
    }

}