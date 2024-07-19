using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class EditProfilePageViewModel : BaseViewModel
    {
        public EditProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            Regions = new ObservableCollection<TblRegions>();
            Provinces = new ObservableCollection<TblProvinces>();
            Municipalities = new ObservableCollection<TblMunicipalities>();
            Barangays = new ObservableCollection<TblBarangays>();
            LoadRegionsCommand.ExecuteAsync(null);
        }

        public ObservableCollection<TblRegions> Regions { get; }
        public ObservableCollection<TblProvinces> Provinces { get; }
        public ObservableCollection<TblMunicipalities> Municipalities { get; }
        public ObservableCollection<TblBarangays> Barangays { get; }

        [ObservableProperty]
        private TblRegions _selectedRegion;
        partial void OnSelectedRegionChanged(TblRegions value) => LoadProvincesCommand.ExecuteAsync(null);

        [ObservableProperty]
        private TblProvinces _selectedProvince;
        partial void OnSelectedProvinceChanged(TblProvinces value) => LoadMunicipalitiesCommand.ExecuteAsync(null);

        [ObservableProperty]
        private TblMunicipalities _selectedMunicipality;
        partial void OnSelectedMunicipalityChanged(TblMunicipalities value) => LoadBarangaysCommand.ExecuteAsync(null);

        [ObservableProperty]
        private TblBarangays? _selectedBarangay;

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
        private async Task SaveProfile()
        {
            // Update the user model with the latest data from the view model
            var user = new UserViewModel
            {
                Firstname = Firstname,
                MiddleName = MiddleName,
                Lastname = Lastname,
                ExtensionName = ExtensionName,
                Birthday = Birthday,
                SexDescription = SexDescription,
                Email = Email,
                CivilStatusName = CivilStatusName,
                MobileNumber = MobileNumber,
                Region = SelectedRegion?.RegionName,
                ProvinceName = SelectedProvince?.ProvinceName,
                MunicipalitiesCities = SelectedMunicipality?.MunCity,
                BarangayName = SelectedBarangay?.BarangayName,
                StreetNumber = StreetNumber
            };

            // Save the updated user model, e.g., through a service
            await clientService.SaveProfile(user);
        }
    }
}