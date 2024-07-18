using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel(ClientService clientService) : BaseViewModel(clientService)
{
    [ObservableProperty]
    private string? userName;
    [ObservableProperty]
    private string? welcomeMessage;

    protected override async Task LoadDataAsync()
    {
        try
        {
            var serializedResponse = await SecureStorage.GetAsync("Authentication");
            if (serializedResponse != null)
            {
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);

                var accessToken = loginResponse.AccessToken;
                var refreshToken = loginResponse.RefreshToken;
                var userName = loginResponse.UserName;

                if (!string.IsNullOrEmpty(userName))
                {
                    userName = char.ToUpper(userName[0]) + userName.Substring(1);
                }

                UserName = userName ?? string.Empty;
                WelcomeMessage = $"Welcome {UserName}!";
            }
            else
            {
                // Handle scenario where serializedResponse is null
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"Failed to load profile: {ex.Message}", "OK");
        }
    }
}