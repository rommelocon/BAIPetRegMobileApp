using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private IImage? image;
        [ObservableProperty]
        private bool isRefreshing;

        public HomePageViewModel(ClientService clientService) : base(clientService)
        {}

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
        private async Task ExecuteRefresh()
        {
            await LoadPetRegistrationsAsync();
            IsRefreshing = false;
        }

        private async Task LoadPetRegistrationsAsync()
        {
            try
            {
                IsBusy = true;
                var registrations = await clientService.GetPetRegistrationsAsync();
                if (registrations != null)
                {
                    PetRegistrations.Clear();
                    foreach (var registration in registrations)
                    {
                        if (!string.IsNullOrEmpty(registration.PetImage1))
                        {
                            registration.PetImageSource = LoadImage(registration.PetImage1);
                        }
                        PetRegistrations.Add(registration);
                    }
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

        [RelayCommand]
        private async Task GoBack()
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }
    }
}