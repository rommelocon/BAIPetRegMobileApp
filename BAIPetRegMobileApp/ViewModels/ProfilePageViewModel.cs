using BAIPetRegMobileApp.Services;

namespace BAIPetRegMobileApp.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            _ = InitializeProfileAsync();
        }

        public async Task InitializeProfileAsync()
        {
            await LoadProfile(user =>
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
                FullName = $"{Firstname} {MiddleName} {Lastname} {ExtensionName}";
            });
        }
    }
}