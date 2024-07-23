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
    [ObservableProperty]
    private string welcomeMessage;

    public HomePageViewModel(ClientService clientService) : base(clientService)
    {
        _ = InitializeProfileAsync();
    }
    public async Task InitializeProfileAsync()
    {
        await LoadProfile();
    }

    private async Task LoadProfile()
    {
        try
        {
            UserName = user.UserName;
            WelcomeMessage = $"Welcome {UserName}!";
        });
    }
}