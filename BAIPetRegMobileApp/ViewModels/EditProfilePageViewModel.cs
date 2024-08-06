using BAIPetRegMobileApp.Models.User;
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
            Regions = new ObservableCollection<Regions>();
            Provinces = new ObservableCollection<Provinces>();
            Municipalities = new ObservableCollection<Municipalities>();
            Barangays = new ObservableCollection<Barangays>();
            SexType = new ObservableCollection<SexType>();
            InitializeAsync();
        }

        public ObservableCollection<Regions> Regions { get; }
        public ObservableCollection<Provinces> Provinces { get; }
        public ObservableCollection<Municipalities> Municipalities { get; }
        public ObservableCollection<Barangays> Barangays { get; }
        public ObservableCollection<SexType> SexType { get; }

        [ObservableProperty] private Regions? selectedRegion; 
        [ObservableProperty] private Provinces? selectedProvince; 
        [ObservableProperty] private Municipalities? selectedMunicipality;
        [ObservableProperty] private Barangays? selectedBarangay;
        [ObservableProperty] private SexType? selectedSexType;

        private async void InitializeAsync()
        {
            IsBusy = true;
            try
            {
                await InitializeProfileAsync();
                await LoadRegionsAsync();
                await LoadSexTypeAsync();
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

        async partial void OnSelectedRegionChanged(Regions value)
        {
            Provinces.Clear();
            Municipalities.Clear();
            Barangays.Clear();
            SelectedProvince = null;
            SelectedMunicipality = null;
            SelectedBarangay = null;
            await LoadProvincesAsync();
        }

        async partial void OnSelectedProvinceChanged(Provinces value)
        {
            Municipalities.Clear();
            Barangays.Clear();
            SelectedMunicipality = null;
            SelectedBarangay = null;
            await LoadMunicipalitiesAsync();
        }

        async partial void OnSelectedMunicipalityChanged(Municipalities value)
        {
            Barangays.Clear();
            SelectedBarangay = null;
            await LoadBarangaysAsync();
        }

        private async Task LoadRegionsAsync()
        {
            await LoadCollectionAsync(clientService.GetRegionsAsync, Regions);
        }

        private async Task LoadProvincesAsync()
        {
            await LoadCollectionAsync(() => clientService.GetProvincesByRegionCodeAsync(SelectedRegion?.Rcode), Provinces);
        }

        private async Task LoadMunicipalitiesAsync()
        {
            await LoadCollectionAsync(() => clientService.GetMunicipalitiesByProvinceCodeAsync(SelectedProvince?.ProvCode), Municipalities);
        }

        private async Task LoadBarangaysAsync()
        {
            await LoadCollectionAsync(() => clientService.GetBarangaysByMunicipalityCodeAsync(SelectedMunicipality?.MunCode), Barangays);
        }

        private async Task LoadSexTypeAsync()
        {
            await LoadCollectionAsync(clientService.GetSexType, SexType);
        }

        [RelayCommand]
        public async Task SaveProfileAsync()
        {
            IsBusy = true;
            try
            {
                // Update UserViewModel with selected values
                if (UserViewModel != null)
                {
                    UserViewModel.SexID = SelectedSexType?.SexID;
                    UserViewModel.SexDescription = SelectedSexType?.SexDescription;
                    UserViewModel.RcodeNum = SelectedRegion?.Rcode;
                    UserViewModel.Region = SelectedRegion?.RegionName;
                    UserViewModel.PcodeNum = SelectedProvince?.ProvCode;
                    UserViewModel.ProvinceName = SelectedProvince?.ProvinceName;
                    UserViewModel.McodeNum = SelectedMunicipality?.MunCode;
                    UserViewModel.MunicipalitiesCities = SelectedMunicipality?.MunCity;
                    UserViewModel.Bcode = SelectedBarangay?.Bcode;
                    UserViewModel.BarangayName = SelectedBarangay?.BarangayName;
                    UserViewModel.FullAddress = $"{SelectedRegion?.RegionName} {SelectedProvince?.ProvinceName} {SelectedMunicipality?.MunCity} {SelectedBarangay?.BarangayName}".Trim();
                }

                var response = await clientService.UpdateProfileAsync(UserViewModel);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.GoToAsync("//ProfilePage");
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
