using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class PetInformationPageViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private PetRegistration? petRegistration;

        public PetInformationPageViewModel(ClientService clientService) : base(clientService)
        { }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("PetRegistrationID"))
            {
                string id = query["PetRegistrationID"].ToString()!;
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        PetRegistration = await clientService.GetPetRegistrationByIdAsync(id);
                        await LoadPetImagesAsync(id);
                    }
                    catch (Exception ex)
                    {
                        await HandleException(ex);
                    }
                };
            }
        }

        private async Task LoadPetImagesAsync(string id)
        {
            IsBusy = true;
            try
            {
                var registrations = await clientService.GetPetRegistrationByIdAsync(id);
                PetGetImage1 = LoadImage(registrations.PetImage1!);
                PetGetImage2 = LoadImage(registrations.PetImage2!);
                PetGetImage3 = LoadImage(registrations.PetImage3!);
                PetGetImage4 = LoadImage(registrations.PetImage4!);
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
