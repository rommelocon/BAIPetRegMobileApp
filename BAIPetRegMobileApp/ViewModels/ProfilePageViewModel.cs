using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNet.Identity;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        public ProfilePageViewModel(ClientService clientService) : base(clientService)
        {
        }
    }
}
