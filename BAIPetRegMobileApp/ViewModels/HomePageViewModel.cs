﻿using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string? userName;
    [ObservableProperty]
    private string? welcomeMessage;

    // add other fields as needed

    public AsyncRelayCommand LoadProfileCommand { get; }

    public HomePageViewModel(ClientService clientService)
    {
        this.clientService = clientService;
        LoadProfileCommand = new AsyncRelayCommand(LoadProfile);
    }

    private async Task LoadProfile()
    {
        await LoadProfile(user =>
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

                if (!string.IsNullOrEmpty(userName))
                {
                    // Upper case the first character and concatenate with the rest of the string
                    userName = char.ToUpper(userName[0]) + userName.Substring(1);
                }

                // Use these properties as needed
                UserName = userName ?? string.Empty;
                WelcomeMessage = $"Welcome {UserName}!";
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
            await Shell.Current.DisplayAlert("Error", $"Failed to load profile: {ex.Message}", "OK");
        }
    }
}