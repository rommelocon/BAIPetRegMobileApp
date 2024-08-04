using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class PetInformationPageViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private PetRegistration petRegistration;

        private readonly ClientService clientService;

        public PetInformationPageViewModel(ClientService clientService) : base(clientService)
        {
            this.clientService = clientService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("PetRegistrationID"))
            {
                string id = query["PetRegistrationID"].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    // Load the pet registration details based on this ID
                    await LoadPetRegistrationDetailsAsync(id);
                }
            }
        }

        private async Task LoadPetRegistrationDetailsAsync(string id)
        {
            try
            {
                IsBusy = true;

                // Fetch pet registration details using the ClientService
                PetRegistration = await clientService.GetPetRegistrationByIdAsync(id);
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
