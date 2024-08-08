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
        private readonly ProfilePageViewModel _profilePageViewModel;
        public EditProfilePageViewModel(ClientService clientService, ProfilePageViewModel profilePageViewModel) : base(clientService)
        {
            Regions = new ObservableCollection<Regions>();
            Provinces = new ObservableCollection<Provinces>();
            Municipalities = new ObservableCollection<Municipalities>();
            Barangays = new ObservableCollection<Barangays>();
            SexType = new ObservableCollection<SexType>();
            _profilePageViewModel = profilePageViewModel;
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

                // Set the initial selected values based on UserData
                SelectedSexType = SexType.FirstOrDefault(s => s.SexID == UserData?.SexID);
                SelectedRegion = Regions.FirstOrDefault(r => r.Rcode == UserData?.RcodeNum);

                if (SelectedRegion != null)
                {
                    await LoadProvincesAsync();
                    SelectedProvince = Provinces.FirstOrDefault(p => p.ProvCode == UserData?.PcodeNum);
                }

                if (SelectedProvince != null)
                {
                    await LoadMunicipalitiesAsync();
                    SelectedMunicipality = Municipalities.FirstOrDefault(m => m.MunCode == UserData?.McodeNum);
                }

                if (SelectedMunicipality != null)
                {
                    await LoadBarangaysAsync();
                    SelectedBarangay = Barangays.FirstOrDefault(b => b.Bcode == UserData?.Bcode);
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
                // Update UserData with selected values
                if (UserData != null)
                {
                    UserData.SexID = SelectedSexType?.SexID;
                    UserData.SexDescription = SelectedSexType?.SexDescription;
                    UserData.RcodeNum = SelectedRegion?.Rcode;
                    UserData.Region = SelectedRegion?.RegionName;
                    UserData.PcodeNum = SelectedProvince?.ProvCode;
                    UserData.ProvinceName = SelectedProvince?.ProvinceName;
                    UserData.McodeNum = SelectedMunicipality?.MunCode;
                    UserData.MunicipalitiesCities = SelectedMunicipality?.MunCity;
                    UserData.Bcode = SelectedBarangay?.Bcode;
                    UserData.BarangayName = SelectedBarangay?.BarangayName;
                    UserData.FullAddress = $"{SelectedRegion?.RegionName} {SelectedProvince?.ProvinceName} {SelectedMunicipality?.MunCity} {SelectedBarangay?.BarangayName}".Trim();
                }

                var response = await clientService.UpdateProfileAsync(UserData!);

                if (response.IsSuccessStatusCode)
                {
                    _profilePageViewModel.InitializeProfilePage();
                    await Shell.Current.GoToAsync("//profile");
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
