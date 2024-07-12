using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    private string userName;

    [ObservableProperty] 
    private bool isAuthenticated;

    private readonly ClientService clientService;

    public HomePageViewModel(ClientService clientService)
    {
        this.clientService = clientService;
        GetUserNameFromSecuredStorage();
    }

    private async void GetUserNameFromSecuredStorage()
    {
        var serializedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
        if (serializedLoginResponseInStorage != null)
        {
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedLoginResponseInStorage);
            if (loginResponse != null)
            {
                UserName = loginResponse.UserName;
                IsAuthenticated = true;
            }
        }
        else
        {
            IsAuthenticated = false;
        }
        OnPropertyChanged(nameof(UserName));
        OnPropertyChanged(nameof(IsAuthenticated));
    }
}