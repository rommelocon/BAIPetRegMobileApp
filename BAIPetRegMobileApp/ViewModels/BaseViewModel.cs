using Android.Service.Autofill;
using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        protected readonly ClientService clientService;

        [ObservableProperty] private bool isProfileLoaded;
        [ObservableProperty] private bool isPetRegisteredLoaded;
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private string? welcomeMessage;
        [ObservableProperty] private ObservableCollection<PetRegistration> petRegistrations = new();
        [ObservableProperty] private ImageSource? petGetImage1;
        [ObservableProperty] private ImageSource? petGetImage2;
        [ObservableProperty] private ImageSource? petGetImage3;
        [ObservableProperty] private ImageSource? petGetImage4;
        [ObservableProperty] private User? userData;

        public BaseViewModel(ClientService clientService)
        {
            this.clientService = clientService;
        }

        protected async Task HandleException(Exception ex) =>
            await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");

        protected async Task LoadProfile()
        {
            if (IsProfileLoaded) return;

            try
            {
                IsBusy = true;
                UserData = await clientService.GetProfile();
                if (UserData != null)
                {
                    WelcomeMessage = $"Welcome {UserData.Firstname ?? UserData.UserName}!";
                    IsProfileLoaded = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No profile data found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
            finally { IsBusy = false; }
        }

        public async Task InitializeProfileAsync()
        {
            await LoadProfile();
        }

        public async Task LoadCollectionAsync<T>(Func<Task<IEnumerable<T>>> loadFunc, ObservableCollection<T> collection)
        {
            try
            {
                IsBusy = true;
                collection.Clear();
                var items = await loadFunc();
                foreach (var item in items) collection.Add(item);
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
            finally { IsBusy = false; }
        }

        public ImageSource LoadImage(string imageName) =>
            ImageSource.FromStream(() => clientService.GetPetImageAsync(imageName).Result);
    }
}