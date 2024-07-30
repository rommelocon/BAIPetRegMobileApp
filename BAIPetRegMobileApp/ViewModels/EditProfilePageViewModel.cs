using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class EditProfilePageViewModel : BaseViewModel
    {
        public EditProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            _ = InitializeProfileAsync();
            Regions = new ObservableCollection<TblRegions>();
            Provinces = new ObservableCollection<TblProvinces>();
            Municipalities = new ObservableCollection<TblMunicipalities>();
            Barangays = new ObservableCollection<TblBarangays>();
            SexType = new ObservableCollection<TblSexType>();
            LoadRegionsCommand.ExecuteAsync(null);
            LoadSexTypeCommand.ExecuteAsync(null);
        }

        public ObservableCollection<TblRegions> Regions { get; }
        public ObservableCollection<TblProvinces> Provinces { get; }
        public ObservableCollection<TblMunicipalities> Municipalities { get; }
        public ObservableCollection<TblBarangays> Barangays { get; }
        public ObservableCollection<TblCivilStatus> CivilStatus { get; }
        public ObservableCollection<TblSexType> SexType { get; }

        [ObservableProperty]
        private TblRegions selectedRegion;
        partial void OnSelectedRegionChanged(TblRegions value)
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
        private TblProvinces selectedProvince;
        partial void OnSelectedProvinceChanged(TblProvinces value)
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
        private TblMunicipalities selectedMunicipality;
        partial void OnSelectedMunicipalityChanged(TblMunicipalities value)
        {
            // Clear related selection
            SelectedBarangay = null;
            Barangays.Clear();

            // Load barangays for the selected municipality
            LoadBarangaysCommand.ExecuteAsync(null);
        }

        [ObservableProperty]
        private TblBarangays selectedBarangay;

        [ObservableProperty]
        private TblSexType selectedSexType;

        [RelayCommand]
        private async Task LoadRegions()
        {
            var regions = await clientService.GetRegionsAsync();
            Regions.Clear();
            foreach (var region in regions)
            {
                Regions.Add(region);
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
                    Birthday = this.Birthday,
                    MobileNumber = this.MobileNumber,
                    Region = SelectedRegion?.RegionName,
                    ProvinceName = SelectedProvince?.ProvinceName,
                    MunicipalitiesCities = SelectedMunicipality?.MunCity,
                    BarangayName = SelectedBarangay?.BarangayName,
                    ProfilePicture = this.ProfilePicture,
                    FullAddress = $"{Region} {MunicipalitiesCities} {ProvinceName} {BarangayName}".Trim(),
                };

                var response = await clientService.UpdateProfileAsync(updatedUser);
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }
    }
}
