using BAIPetRegMobileApp.Models;
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

    public async Task<HomePageViewModel> GetHomePageViewModel(string username)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await httpClient.GetAsync($"/Account/{username}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<HomePageViewModel>(json);
        return user!;
    }

    public async Task<ProfilePageViewModel> GetProfilePageViewModel(string username)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await httpClient.GetAsync($"/Account/{username}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<ProfilePageViewModel>(json);
        return user!;
    }
}