using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : ObservableObject
{
    private string _userName;
   
    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }

    private readonly ClientService _clientService;
        
    public HomePageViewModel(ClientService clientService)
    {
        _clientService = clientService;
        InitializeAsync();
    }

    public async Task InitializeAsync()
    {
        try
        {
            UserName = await _clientService.GetUserInfo();
        }
        catch (Exception ex)
        {
            // Handle exception as needed (logging, UI feedback, etc.)
            Console.WriteLine($"Error initializing user info: {ex.Message}");
        }
    }
}
