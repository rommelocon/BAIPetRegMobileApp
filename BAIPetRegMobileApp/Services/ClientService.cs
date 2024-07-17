using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;
using System.Text.Json;
using BAIPetRegMobileApp.ViewModels;
using BAIPetRegMobileApp.Api.Models;

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
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/Account/login", model);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<LoginResponse>();

                if (response is not null)
                {
                    var serializedResponse = JsonSerializer.Serialize(
                        new LoginResponse()
                        {
                            AccessToken = response.AccessToken,
                            RefreshToken = response.RefreshToken,
                            UserName = response.UserName
                        });

                    await SecureStorage.SetAsync("Authentication", serializedResponse);

                    // Navigate to HomePage
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

        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    public async Task<UserProfileDto> GetProfile()
    {
        // Retrieve the authentication data from secure storage
        var serializedResponse = await SecureStorage.GetAsync("Authentication");

        if (serializedResponse != null)
        {
            // Deserialize the response to get the username
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName))
            {
                // Make the API request with the retrieved username
                var httpClient = httpClientFactory.CreateClient("custom-httpclient");
                var result = await httpClient.GetAsync($"/Account/{loginResponse.UserName}");

                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadFromJsonAsync<UserProfileDto>();
                    try
                    {
                        if (responseContent is not null)
                        {
                            return responseContent;
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Alert", "Failed to retrieve profile data. Please try again.", "Ok");
                        }
                    }
                    catch (JsonException ex)
                    {
                        await Shell.Current.DisplayAlert("Alert", $"Failed to parse profile data: {ex.Message}", "Ok");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", "Failed to retrieve profile. Please try again.", "Ok");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Username is not available. Please log in again.", "Ok");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Alert", "Authentication data not found. Please log in.", "Ok");
        }

        return null;
    }
}