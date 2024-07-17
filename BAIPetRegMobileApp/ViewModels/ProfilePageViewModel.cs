using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

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
        private string birthday;

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

        // Public method to initialize profile
        public async Task InitializeProfile()
        {
            await LoadProfile();
        }


        private async Task LoadProfile()
        {
            try
            {
                var userProfile = await clientService.GetProfile();

                if (userProfile != null)
                {
                    // Update the ViewModel properties with the profile data
                    UserName = userProfile.UserName;
                    Email = userProfile.Email;
                    Firstname = userProfile.Firstname;
                    Lastname = userProfile.Lastname;
                    Birthday = userProfile.Birthday;
                    MobileNumber = userProfile.MobileNumber;
                    Region = userProfile.Region;
                    ProvinceName = userProfile.ProvinceName;
                    MunicipalitiesCities = userProfile.MunicipalitiesCities;
                    BarangayName = userProfile.BarangayName;
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
