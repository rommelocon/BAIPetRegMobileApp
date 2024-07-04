using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty]
    private LoginModel loginModel;

    [ObservableProperty]
    private string userName;
    [ObservableProperty]
    private bool isAuthenticated;

    private readonly ClientService clientService;

    public HomePageViewModel(ClientService clientService)
    {
        this.clientService = clientService;
        LoginModel = new();
        isAuthenticated = false;
        GetUserNameFromSecuredStorage();
    }

    [RelayCommand]
    private async Task Login()
    {
        await clientService.Login(LoginModel);
        GetUserNameFromSecuredStorage();
    }

    private async void GetUserNameFromSecuredStorage()
    {
        if (!string.IsNullOrEmpty(UserName) && userName! != "Guest")
        {
            isAuthenticated = true;
            return;
        }
        var serializedLoginResponseInStorage = await SecureStorage.Default.GetAsync("Authentication");
        if(serializedLoginResponseInStorage != null) 
        {
            UserName = JsonSerializer.Deserialize<LoginResponse>(serializedLoginResponseInStorage)!.UserName!;
            isAuthenticated = true;
            return;
        }
        UserName = "Guest";
        isAuthenticated = false;
    }

    [RelayCommand]
    public async Task Logout()
    {
        SecureStorage.Default.Remove("Authentication");
        isAuthenticated = false;
        UserName = "Guest";
        await Shell.Current.GoToAsync("..");
    }
}
