using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

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
            IsProfileLoaded = false;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("PetRegistrationID"))
            {
                string id = query["PetRegistrationID"].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                            // Load the pet registration details based on this ID
                            await LoadPetRegistrationDetailsAsync(id);
                            await LoadPetImagesAsync(id);
                       
                    }
                    catch (Exception ex)
                    {
                        await HandleException(ex);
                    }
                }
            }
        }

        private async Task LoadPetRegistrationDetailsAsync(string id)
        {
            try
            {
                IsBusy = true;
                PetRegistration = await clientService.GetPetRegistrationByIdAsync(id);
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
            finally
            {
                IsBusy = false;
                IsProfileLoaded = true;
            }
        }
    }
}
