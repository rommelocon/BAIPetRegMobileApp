using BAIPetRegMobileApp.Services;

namespace BAIPetRegMobileApp.ViewModels;
public partial class HomePageViewModel : BaseViewModel
{
    public HomePageViewModel(ClientService clientService) : base(clientService)
    {
        _ = InitializeProfileAsync();
    }
}