using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.Input;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(ClientService clientService) : base(clientService)
        {
            if (!IsPetRegisteredLoaded)
                LoadPetRegistrationsCommand.ExecuteAsync(null);
            IsPetRegisteredLoaded = true;
        }

        [RelayCommand]
        public async Task ShowMoreAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return;
            await Shell.Current.GoToAsync(nameof(PetInformationPage), new Dictionary<string, object>
            {
                { "PetRegistrationID", id }
            });
        }

        [RelayCommand]
        private async Task LoadPetRegistrationsAsync()
        {
            try
            {
                IsBusy = true;
                var registrations = await clientService.GetPetRegistrationsAsync();
                PetRegistrations.Clear();
                foreach (var registration in registrations)
                {
                    PetRegistrations.Add(registration);
                    var fileName = registration.PetImage1;
                    if (fileName != null)
                        registration.PetImageSource = ImageSource.FromStream(() => clientService.GetPetImageAsync(fileName).Result);
                }
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

        public async Task RefreshPetRegistrationsAsync()
        {
            await LoadPetRegistrationsAsync();
        }
    }
}