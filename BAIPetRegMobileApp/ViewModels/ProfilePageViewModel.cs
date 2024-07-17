using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNet.Identity;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        private ClientService clientService;

        public ProfilePageViewModel(ClientService clientService)
        {
            this.clientService = clientService;
        }

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;

        [ObservableProperty]
        private int civilStatusCode;

        [ObservableProperty]
        private DateOnly birthday;

        [ObservableProperty]
        private string sexDescription;

        [ObservableProperty]
        private string mobileNumber;

        [ObservableProperty]
        private string region;

        [ObservableProperty]
        private string provinceName;

        [ObservableProperty]
        private string municipalitiesCities;

        [ObservableProperty]
        private string barangayName;

        [ObservableProperty]
        private string civilStatusName;

        [ObservableProperty]
        private string middleName;

        [ObservableProperty]
        private string extensionName;

        [ObservableProperty]
        private byte[] profilePicture;

        [ObservableProperty]
        private string streetAddress;

        [ObservableProperty]
        private string fullAddress;

        [ObservableProperty]
        private string fullName;


        // Public method to initialize profile
        public async Task InitializeProfile()
        {
            await LoadProfile();
        }


        private async Task LoadProfile()
        {
            try
            {
                var user = await clientService.GetProfile();

                if (user != null)
                {
                    // Update the ViewModel properties with the profile data
                    Firstname = user.Firstname;
                    Lastname = user.Lastname;
                    MiddleName = user.MiddleName;
                    ExtensionName = user.ExtensionName;
                    Birthday = user.Birthday; // Assuming ApplicationUser has a DateOnly property for Birthday
                    SexDescription = user.SexDescription;
                    MobileNumber = user.MobileNumber;
                    UserName = user.UserName;
                    Email = user.Email;
                    Region = user.Region;
                    ProvinceName = user.ProvinceName;
                    MunicipalitiesCities = user.MunicipalitiesCities;
                    BarangayName = user.BarangayName;
                    ProfilePicture = user.ProfilePicture;
                    CivilStatusName = user.CivilStatusName;
                    FullAddress = $"{StreetAddress} {BarangayName} {MunicipalitiesCities} {ProvinceName} {Region}";
                    FullName = $"{Firstname} {MiddleName} {Lastname} {ExtensionName}";
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No profile data found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load profile: {ex.Message}", "OK");
            }
        }
    }
}
