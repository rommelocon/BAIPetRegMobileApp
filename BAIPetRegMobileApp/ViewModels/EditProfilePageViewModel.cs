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
            Regions = new ObservableCollection<Regions>();
            Provinces = new ObservableCollection<Provinces>();
            Municipalities = new ObservableCollection<Municipalities>();
            Barangays = new ObservableCollection<Barangays>();
            SexType = new ObservableCollection<SexType>();

            _ = InitializeProfileAsync();
            _ = LoadRegionsAsync();
            _ = LoadSexTypeAsync();
        }

        public ObservableCollection<Regions> Regions { get; }
        public ObservableCollection<Provinces> Provinces { get; }
        public ObservableCollection<Municipalities> Municipalities { get; }
        public ObservableCollection<Barangays> Barangays { get; }
        public ObservableCollection<SexType> SexType { get; }

        [ObservableProperty]
        private Regions selectedRegion;
        [ObservableProperty]
        private Provinces selectedProvince;
        [ObservableProperty]
        private Municipalities selectedMunicipality;
        [ObservableProperty]
        private Barangays selectedBarangay;
        [ObservableProperty]
        private SexType selectedSexType;

        partial void OnSelectedRegionChanged(Regions value)
        {
            if (value != null)
            {
                Provinces.Clear();
                SelectedProvince = null;
                Municipalities.Clear();
                SelectedMunicipality = null;
                Barangays.Clear();
                SelectedBarangay = null;

                _ = LoadProvincesAsync();
            }
        }

        partial void OnSelectedProvinceChanged(Provinces value)
        {
            if (value != null)
            {
                Municipalities.Clear();
                SelectedMunicipality = null;
                Barangays.Clear();
                SelectedBarangay = null;

                _ = LoadMunicipalitiesAsync();
            }
        }

        partial void OnSelectedMunicipalityChanged(Municipalities value)
        {
            if (value != null)
            {
                Barangays.Clear();
                SelectedBarangay = null;

                _ = LoadBarangaysAsync();
            }
        }

        private async Task LoadRegionsAsync()
        {
            IsBusy = true;
            try
            {
                var regions = await clientService.GetRegionsAsync();
                Regions.Clear();
                foreach (var region in regions)
                {
                    Regions.Add(region);
                }
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

        private async Task LoadProvincesAsync()
        {
            IsBusy = true;
            try
            {
                var provinces = await clientService.GetProvincesByRegionCodeAsync(SelectedRegion?.Rcode);
                Provinces.Clear();
                foreach (var province in provinces)
                {
                    Provinces.Add(province);
                }
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

        private async Task LoadMunicipalitiesAsync()
        {
            IsBusy = true;
            try
            {
                var municipalities = await clientService.GetMunicipalitiesByProvinceCodeAsync(SelectedProvince?.ProvCode);
                Municipalities.Clear();
                foreach (var municipality in municipalities)
                {
                    Municipalities.Add(municipality);
                }
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

        private async Task LoadBarangaysAsync()
        {
            IsBusy = true;
            try
            {
                var barangays = await clientService.GetBarangaysByMunicipalityCodeAsync(SelectedMunicipality?.MunCode);
                Barangays.Clear();
                foreach (var barangay in barangays)
                {
                    Barangays.Add(barangay);
                }
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

        private async Task LoadSexTypeAsync()
        {
            IsBusy = true;
            try
            {
                var sexTypes = await clientService.GetSexType();
                SexType.Clear();
                foreach (var sexType in sexTypes)
                {
                    SexType.Add(sexType);
                }
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

        [RelayCommand]
        public async Task SaveProfileAsync()
        {
            IsBusy = true;
            try
            {
                var updatedUser = new User
                {
                    UserName = UserName,
                    Email = Email,
                    Firstname = Firstname,
                    Lastname = Lastname,
                    MiddleName = MiddleName,
                    ExtensionName = ExtensionName,
                    SexID = SelectedSexType?.SexID,
                    SexDescription = SelectedSexType?.SexDescription,
                    Birthday = Birthday,
                    MobileNumber = MobileNumber,
                    RcodeNum = SelectedRegion?.Rcode,
                    Region = SelectedRegion?.RegionName,
                    PcodeNum = SelectedProvince?.ProvCode,
                    ProvinceName = SelectedProvince?.ProvinceName,
                    McodeNum = SelectedMunicipality?.MunCode,
                    MunicipalitiesCities = SelectedMunicipality?.MunCity,
                    Bcode = SelectedBarangay?.Bcode,
                    BarangayName = SelectedBarangay?.BarangayName,
                    ProfilePicture = ProfilePicture,
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
            finally
            {
                IsBusy = false;
            }
        }
    }
}