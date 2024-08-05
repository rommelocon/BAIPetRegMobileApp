using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kotlin.Properties;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        protected readonly ClientService clientService;
        [ObservableProperty] private bool isProfileLoaded;
        [ObservableProperty] private bool isPetRegisteredLoaded = false;
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private User? userViewModel;
        [ObservableProperty] private string? userName;
        [ObservableProperty] private string? email;
        [ObservableProperty] private string? firstname;
        [ObservableProperty] private string? lastname;
        [ObservableProperty] private int? civilStatusCode;
        [ObservableProperty] private DateTime? birthday;
        [ObservableProperty] private int? sexID;
        [ObservableProperty] private string? sexDescription;
        [ObservableProperty] private string? mobileNumber;
        [ObservableProperty] private string? rcodeNum;
        [ObservableProperty] private string? region;
        [ObservableProperty] private string? pcodeNum;
        [ObservableProperty] private string? provinceName;
        [ObservableProperty] private string? mcodeNum;
        [ObservableProperty] private string? municipalitiesCities;
        [ObservableProperty] private string? bcode;
        [ObservableProperty] private string? barangayName;
        [ObservableProperty] private string? middleName;
        [ObservableProperty] private string? extensionName;
        [ObservableProperty] private byte[]? profilePicture;
        [ObservableProperty] private string? fullAddress;
        [ObservableProperty] private string? fullName;
        [ObservableProperty] private string? welcomeMessage;
        [ObservableProperty] private ObservableCollection<PetRegistration> petRegistrations = new ObservableCollection<PetRegistration>();
        [ObservableProperty]
        private ImageSource _petGetImage1;
        [ObservableProperty]
        private ImageSource _petGetImage2;
        [ObservableProperty]
        private ImageSource _petGetImage3;
        [ObservableProperty]
        private ImageSource _petGetImage4;

        public BaseViewModel(ClientService clientService)
        {
            this.clientService = clientService;
        }

        // Method to handle common error display
        protected async Task HandleException(Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }

        // Method to handle common profile loading
        protected async Task LoadProfile(Action<User> updateProperties)
        {
            try
            {
                //if (isProfileLoaded) return;
                var user = await clientService.GetProfile();
                if (user != null)
                {
                    updateProperties.Invoke(user);
                    //isProfileLoaded = true;
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
        }

        public async Task InitializeProfileAsync()
        {
            IsBusy = true;
            await LoadProfile(user =>
            {
                WelcomeMessage = $"Welcome {(string.IsNullOrEmpty(user.Firstname) ? user.UserName : user.Firstname)}!";
                Firstname = user.Firstname;
                Lastname = user.Lastname;
                MiddleName = user.MiddleName;
                ExtensionName = user.ExtensionName;
                Birthday = user.Birthday;
                SexID = user.SexID;
                SexDescription = user.SexDescription;
                MobileNumber = user.MobileNumber;
                UserName = user.UserName;
                Email = user.Email;
                RcodeNum = user.RcodeNum;
                Region = user.Region;
                PcodeNum = user.PcodeNum;
                ProvinceName = user.ProvinceName;
                McodeNum = user.McodeNum;
                MunicipalitiesCities = user.MunicipalitiesCities;
                Bcode = user.Bcode;
                BarangayName = user.BarangayName;
                ProfilePicture = user.ProfilePicture;
                FullAddress = user.FullAddress;
                FullName = $"{Firstname} {MiddleName} {Lastname} {ExtensionName}".Trim();
            });
            IsBusy = false;
        }

        public async Task LoadCollectionAsync<T>(Func<Task<IEnumerable<T>>> loadFunc, ObservableCollection<T> collection)
        {
            collection.Clear();
            try
            {
                var items = await loadFunc();
                foreach (var item in items)
                {
                    collection.Add(item);
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }

        [RelayCommand]
        public async Task LoadPetImagesAsync(string id)
        {
            try
            {
                IsBusy = true;
                var registrations = await clientService.GetPetRegistrationByIdAsync(id);
                PetGetImage1 = ImageSource.FromStream(() => clientService.GetPetImageAsync(registrations.PetImage1).Result);
                PetGetImage2 = ImageSource.FromStream(() => clientService.GetPetImageAsync(registrations.PetImage2).Result);
                PetGetImage3 = ImageSource.FromStream(() => clientService.GetPetImageAsync(registrations.PetImage3).Result);
                PetGetImage4 = ImageSource.FromStream(() => clientService.GetPetImageAsync(registrations.PetImage4).Result);
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