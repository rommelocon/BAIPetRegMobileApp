using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    private readonly ClientService clientService;
    private string _username;
    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);

    }
    public HomePageViewModel(ClientService clientService)
    {
        this.clientService = clientService;
    }

    public async Task LoadUserInfo()
    {
        var userInfo = await clientService.GetUser();
        if (userInfo != null)
        {
            Username = userInfo.UserName;
        }
        else
        {
            Username = string.Empty;
        }
    }
}
