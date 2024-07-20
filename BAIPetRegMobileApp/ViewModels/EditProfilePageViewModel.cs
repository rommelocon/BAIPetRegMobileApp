using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class EditProfilePageViewModel : BaseViewModel
    {
        private readonly ClientService clientService;

        public EditProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            UserViewModel = new UserViewModel();
            this.clientService = clientService;
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
        private TblBarangays _selectedBarangay;

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
        public void Refresh()
        {
            // Reset or clear necessary properties and collections
            SelectedRegion = null;
            SelectedProvince = null;
            SelectedMunicipality = null;
            SelectedBarangay = null;
        }

        private async Task InitializeProfileAsync()
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