using BAIPetRegMobileApp.Services;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels;
public partial class PetRegisterViewModel : BaseViewModel
{
    public PetRegisterViewModel(ClientService clientService) : base(clientService)
    {
       
    }
}