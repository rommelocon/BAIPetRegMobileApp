using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class EditProfilePageViewModel(ClientService clientService) : BaseViewModel(clientService)
    {
        private readonly ClientService clientService = clientService;
        private readonly JsonSerializerOptions serializerOptions;

        // Properties for data binding
        public List<TblRegions> Regions { get; private set; }

        [ObservableProperty]
        private string? selectedRegion;

        [ObservableProperty]
        private string? selectedProvince;

        [ObservableProperty]
        private string? selectedMunicipality;

        [ObservableProperty]
        private string? selectedBarangay;

        [ObservableProperty]
        private DateOnly birthday;

        protected override async Task LoadDataAsync()
        {
            await GetRegionsAsync();
        }

        public async Task<List<TblRegions>> GetRegionsAsync()
        {
           
        }
    }
}
