using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private IImage? image;

        public HomePageViewModel(ClientService clientService) : base(clientService)
        {
            if (!IsPetRegisteredLoaded)
            {
                LoadPetRegistrationsCommand.ExecuteAsync(null);
            }
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
                    
                    var fileName = registration.PetImage1;
                    if (fileName != null)
                    {
                        IsBusy = true;
                        var imageStream = await clientService.GetPetImageAsync(fileName);
                        registration.PetImageSource = ImageSource.FromStream(() => imageStream);
                        IsBusy = false;
                    }
                    PetRegistrations.Add(registration);
                    continue;
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