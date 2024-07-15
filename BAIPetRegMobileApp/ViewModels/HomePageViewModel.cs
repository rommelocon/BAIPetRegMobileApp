using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    private ClientService clientService;

    [ObservableProperty]
    private string userName;

    // add other fields as needed

    public AsyncRelayCommand LoadProfileCommand { get; }

    public HomePageViewModel(ClientService clientService)
    {
        this.clientService = clientService;
        LoadProfileCommand = new AsyncRelayCommand(LoadProfile);
    }

    private async Task LoadProfile()
    {
        try
        {
            // Get the username of the current authenticated user
            var serializedResponse = await SecureStorage.GetAsync("Authentication");
            if (serializedResponse != null)
            {
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);

                // Now you can access individual properties of loginResponse
                var accessToken = loginResponse.AccessToken;
                var refreshToken = loginResponse.RefreshToken;
                var userName = loginResponse.UserName;

                // Use these properties as needed
                UserName = userName ?? string.Empty;
            }
            else
            {
                // Handle scenario where serializedResponse is null (data not found)
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, such as network errors or server issues
            // Example: Display an error message to the user
            // await DisplayAlert("Error", $"Failed to load profile: {ex.Message}", "OK");
        }
    }
}