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
            CivilStatus = new ObservableCollection<TblCivilStatus>();
            SexType = new ObservableCollection<TblSexType>();
            LoadRegionsCommand.ExecuteAsync(null);
            LoadCivilStatusCommand.ExecuteAsync(null);
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
        partial void OnSelectedRegionChanged(TblRegions value) => LoadProvincesCommand.ExecuteAsync(null);

        [ObservableProperty]
        private TblProvinces selectedProvince;
        partial void OnSelectedProvinceChanged(TblProvinces value) => LoadMunicipalitiesCommand.ExecuteAsync(null);

        [ObservableProperty]
        private TblMunicipalities selectedMunicipality;
        partial void OnSelectedMunicipalityChanged(TblMunicipalities value) => LoadBarangaysCommand.ExecuteAsync(null);

        [ObservableProperty]
        private TblBarangays selectedBarangay;

        [ObservableProperty]
        private TblCivilStatus selectedCivilStatus;

        [ObservableProperty]
        private TblSexType selectedSexType;

        [RelayCommand]
        private async Task LoadRegions()
        {
            var regions = await clientService.GetRegionsAsync();
            Provinces.Clear();
            Municipalities.Clear();
            Barangays.Clear();
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
                Municipalities.Clear();
                Barangays.Clear();
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
                Barangays.Clear();
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
                foreach (var barangay in barangays)
                {
                    Barangays.Add(barangay);
                }
            }
        }

        [RelayCommand]
        private async Task LoadCivilStatus()
        {
            var civilStatuses = await clientService.GetCivilStatus();
            foreach (var civilStatus in civilStatuses)
            {
                CivilStatus.Add(civilStatus);
            }
        }

        [RelayCommand]
        private async Task LoadSexType()
        {
            var sexTypes = await clientService.GetSexType();
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
                var updatedUser = new UserViewModel
                {
                    UserName = this.UserName,
                    Email = this.Email,
                    Firstname = this.Firstname,
                    Lastname = this.Lastname,
                    MiddleName = this.MiddleName,
                    ExtensionName = this.ExtensionName,
                    Birthday = this.Birthday,
                    SexDescription = SelectedCivilStatus.CivilStatus,
                    MobileNumber = this.MobileNumber,
                    Region = SelectedRegion.RegionName,
                    ProvinceName = SelectedProvince.ProvinceName,
                    MunicipalitiesCities = SelectedMunicipality.MunCity,
                    BarangayName = SelectedBarangay.BarangayName,
                    ProfilePicture = this.ProfilePicture,
                    CivilStatusName = SelectedCivilStatus.CivilStatus,
                    StreetNumber = this.StreetNumber,
                    FullAddress = $"{StreetNumber} {Region} {MunicipalitiesCities} {ProvinceName} {BarangayName}",
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
