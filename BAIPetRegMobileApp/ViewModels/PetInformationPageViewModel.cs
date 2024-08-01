using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;

namespace BAIPetRegMobileApp.ViewModels
{
    public class PetInformationPageViewModel : BaseViewModel
    {
        private readonly ClientService clientService;
        public PetInformationPageViewModel(PetRegistration pet, ClientService clientService) : base(clientService)
        {
           this.clientService = clientService;
        }
    }
}
