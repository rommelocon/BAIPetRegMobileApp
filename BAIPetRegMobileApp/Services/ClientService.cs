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
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/login", model);
        var response = await result.Content.ReadFromJsonAsync<LoginResponse>();
        if (result is not null)
        {
            var serializedResponse = JsonSerializer.Serialize(
                new LoginResponse() { AccessToken = response.AccessToken, RefreshToken = response.RefreshToken, UserName = model.UserName });
            await SecureStorage.Default.SetAsync("Authentication", serializedResponse);
        }
    }
}