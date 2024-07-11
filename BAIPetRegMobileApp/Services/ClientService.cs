using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.ViewModels;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace BAIPetRegMobileApp.Services;
public class ClientService
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IServiceProvider serviceProvider;

    public ClientService(IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
    {
        this.httpClientFactory = httpClientFactory;
        this.serviceProvider = serviceProvider;
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
        var json = JsonSerializer.Serialize(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("/Account/login", content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent);

            if (loginResponse != null)
            {
                var serializedResponse = JsonSerializer.Serialize(loginResponse);
                await SecureStorage.SetAsync("Authentication", serializedResponse);

                // Update the Username property in the view model
                var homePageViewModel = serviceProvider.GetService(typeof(HomePageViewModel)) as HomePageViewModel;
                if (homePageViewModel != null)
                {
                    homePageViewModel.UserName = loginResponse.UserName;
                }


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
}