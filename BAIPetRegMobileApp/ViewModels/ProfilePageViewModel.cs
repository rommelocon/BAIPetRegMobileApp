using BAIPetRegMobileApp.Services;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            _ = InitializeProfileAsync();
        }
    }
}
