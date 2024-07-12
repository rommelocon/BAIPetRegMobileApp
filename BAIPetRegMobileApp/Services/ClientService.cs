using BAIPetRegMobileApp.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using BAIPetRegMobileApp.ViewModels;

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
            var responseContent = await result.Content.ReadFromJsonAsync<LoginResponse>();

            if (responseContent is not null)
            {
                var serializedResponse = JsonSerializer.Serialize(
                    new LoginResponse()
                    {
                        AccessToken = responseContent.AccessToken,
                        RefreshToken = responseContent.RefreshToken,
                        UserName = responseContent.UserName
                    });

                await SecureStorage.SetAsync("Authentication", serializedResponse);   
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

    public async Task<UserModel> GetUserInfoAsync()
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        if (SecureStorage.Default.GetAsync("Authentication") is null)
        {
            var result = await httpClient.GetAsync("/Account/user");
            if (result.IsSuccessStatusCode)
            {
                var userInfo = await result.Content.ReadFromJsonAsync<UserModel>();
                return userInfo;
            }
            return null;
        }
        return null;
    }
}