using BAIPetRegMobileApp.Services;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class ProfilePageViewModel(ClientService clientService) : BaseViewModel(clientService)
    {
        protected override async Task LoadDataAsync()
        {
            try
            {
                var user = await clientService.GetProfile();

                if (user != null)
                {
                    Firstname = user.Firstname;
                    Lastname = user.Lastname;
                    MiddleName = user.MiddleName;
                    ExtensionName = user.ExtensionName;
                    Birthday = user.Birthday;
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
                    FullName = string.IsNullOrWhiteSpace(Firstname) && string.IsNullOrWhiteSpace(Lastname) ? UserName : $"{Firstname} {Lastname}";
                    OnPropertyChanged(nameof(FullName));
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
