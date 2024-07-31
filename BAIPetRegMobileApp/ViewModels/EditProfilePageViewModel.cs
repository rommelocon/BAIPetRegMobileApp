using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class EditProfilePageViewModel : BaseViewModel
    {
        public EditProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            _ = InitializeProfileAsync();
            Regions = new ObservableCollection<Regions>();
            Provinces = new ObservableCollection<Provinces>();
            Municipalities = new ObservableCollection<Municipalities>();
            Barangays = new ObservableCollection<Barangays>();
            SexType = new ObservableCollection<SexType>();
            LoadRegionsCommand.ExecuteAsync(null);
            LoadSexTypeCommand.ExecuteAsync(null);
        }

        public ObservableCollection<Regions> Regions { get; }
        public ObservableCollection<Provinces> Provinces { get; }
        public ObservableCollection<Municipalities> Municipalities { get; }
        public ObservableCollection<Barangays> Barangays { get; }
        public ObservableCollection<SexType> SexType { get; }

        [ObservableProperty]
        private Regions selectedRegion;
        partial void OnSelectedRegionChanged(Regions value)
        {
            // Clear related selections
            SelectedProvince = null;
            SelectedMunicipality = null;
            SelectedBarangay = null;
            Provinces.Clear();
            Municipalities.Clear();
            Barangays.Clear();

            // Load provinces for the selected region
            LoadProvincesCommand.ExecuteAsync(null);
        }

        [ObservableProperty]
        private Provinces selectedProvince;
        partial void OnSelectedProvinceChanged(Provinces value)
        {
            // Clear related selections
            SelectedMunicipality = null;
            SelectedBarangay = null;
            Municipalities.Clear();
            Barangays.Clear();

            // Load municipalities for the selected province
            LoadMunicipalitiesCommand.ExecuteAsync(null);
        }

        [ObservableProperty]
        private Municipalities selectedMunicipality;
        partial void OnSelectedMunicipalityChanged(Municipalities value)
        {
            // Clear related selection
            SelectedBarangay = null;
            Barangays.Clear();

            // Load barangays for the selected municipality
            LoadBarangaysCommand.ExecuteAsync(null);
        }

        [ObservableProperty]
        private Barangays selectedBarangay;

        [ObservableProperty]
        private SexType selectedSexType;

        [RelayCommand]
        private async Task LoadRegions()
        {
            var regionsResponse = await clientService.GetRegionsAsync();
            Regions.Clear();
            foreach (var r in regionsResponse)
            {
                Regions.Add(r);
            }
        }

        [RelayCommand]
        private async Task LoadProvinces()
        {
            if (SelectedRegion != null)
            {
                var provinces = await clientService.GetProvincesByRegionCodeAsync(SelectedRegion.Rcode);
                Provinces.Clear();
                foreach (var province in provinces)
                {
                    Provinces.Add(province);
                }
            }
        }

        [RelayCommand]
        private async Task LoadMunicipalities()
        {
            if (SelectedProvince != null)
            {
                var municipalities = await clientService.GetMunicipalitiesByProvinceCodeAsync(SelectedProvince.ProvCode);
                Municipalities.Clear();
                foreach (var municipality in municipalities)
                {
                    Municipalities.Add(municipality);
                }
            }
        }

        [RelayCommand]
        private async Task LoadBarangays()
        {
            if (SelectedMunicipality != null)
            {
                var barangays = await clientService.GetBarangaysByMunicipalityCodeAsync(SelectedMunicipality.MunCode);
                Barangays.Clear();
                foreach (var barangay in barangays)
                {
                    Barangays.Add(barangay);
                }
            }
        }

        [RelayCommand]
        private async Task LoadSexType()
        {
            var sexTypes = await clientService.GetSexType();
            SexType.Clear();
            foreach (var sexType in sexTypes)
            {
                SexType.Add(sexType);
            }
        }

        [RelayCommand]
        public async Task SaveProfile()
        {
            try
            {
                var updatedUser = new User
                {
                    UserName = this.UserName,
                    Email = this.Email,
                    Firstname = this.Firstname,
                    Lastname = this.Lastname,
                    MiddleName = this.MiddleName,
                    ExtensionName = this.ExtensionName,
                    SexID = SelectedSexType.SexID,
                    SexDescription = SelectedSexType.SexDescription,
                    Birthday = this.Birthday,
                    MobileNumber = this.MobileNumber,
                    RcodeNum = SelectedRegion?.Rcode,
                    Region = SelectedRegion?.RegionName,
                    PcodeNum = SelectedProvince?.ProvCode,
                    ProvinceName = SelectedProvince?.ProvinceName,
                    McodeNum = SelectedMunicipality?.MunCode,
                    MunicipalitiesCities = SelectedMunicipality?.MunCity,
                    Bcode = SelectedBarangay?.Bcode,
                    BarangayName = SelectedBarangay?.BarangayName,
                    ProfilePicture = this.ProfilePicture,
                    FullAddress = $"{SelectedRegion?.RegionName} {SelectedProvince?.ProvinceName} {SelectedMunicipality?.MunCity} {SelectedBarangay?.BarangayName}".Trim(),
                };

                var response = await clientService.UpdateProfileAsync(updatedUser);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.GoToAsync(nameof(ProfilePage));
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }
    }
}
