using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        private readonly ClientService _clientService;

        public BaseViewModel(ClientService clientService)
        {
            _clientService = clientService;
        }

        [ObservableProperty]
        private string? userName;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? firstname;

        [ObservableProperty]
        private string? lastname;

        [ObservableProperty]
        private int? civilStatusCode;

        [ObservableProperty]
        private DateOnly? birthday;

        [ObservableProperty]
        private string? sexDescription;

        [ObservableProperty]
        private string? mobileNumber;

        [ObservableProperty]
        private string? region;

        [ObservableProperty]
        private string? provinceName;

        [ObservableProperty]
        private string? municipalitiesCities;

        [ObservableProperty]
        private string? barangayName;

        [ObservableProperty]
        private string? civilStatusName;

        [ObservableProperty]
        private string? middleName;

        [ObservableProperty]
        private string? extensionName;

        [ObservableProperty]
        private byte[]? profilePicture;

        [ObservableProperty]
        private string? streetAddress;

        [ObservableProperty]
        private string? fullAddress;

        [ObservableProperty]
        private string? fullName;

        [ObservableProperty]
        private bool isDataLoaded = false;

        public async Task InitializeAsync()
        {
            if (!IsDataLoaded)
            {
                await LoadDataAsync();
                IsDataLoaded = true;
            }
        }

        protected abstract Task LoadDataAsync();

        public async Task RefreshDataAsync()
        {
            IsDataLoaded = false;
            await InitializeAsync();
        }
    }
}
