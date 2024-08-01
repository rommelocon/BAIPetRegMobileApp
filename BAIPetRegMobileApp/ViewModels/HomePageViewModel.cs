using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(ClientService clientService) : base(clientService)
        {
            PetRegistrations = new ObservableCollection<PetRegistration>();
            LoadPetRegistrationCommand = new AsyncRelayCommand(LoadPetRegistration);
            LoadPetRegistrationCommand.ExecuteAsync(null);
            ExpandCommand = new RelayCommand<PetRegistration>(ToggleExpand);
        }
        public IRelayCommand<PetRegistration> ExpandCommand { get; }
        private void ToggleExpand(PetRegistration item)
        {
            if (PetRegistration == item)
            {
                // Collapse the currently expanded item
                PetRegistration = null;
            }
            else
            {
                // Expand the new item
                PetRegistration = item;
            }
        }
        public ObservableCollection<PetRegistration> PetRegistrations { get; set; }
     
        [ObservableProperty]
        private PetRegistration _petRegistration;

        [ObservableProperty]
        private string? petRegistrationID;

        [ObservableProperty]
        private DateTime? dateEncocde;

        [ObservableProperty]
        private DateTime? dateRegistered;

        [ObservableProperty]
        private string? tagID;

        [ObservableProperty]
        private string? tagDescription;

        [ObservableProperty]
        private string? tagNo;

        [ObservableProperty]
        private string? alias;

        [ObservableProperty]
        private string? clientID;

        [ObservableProperty]
        private string? clientName;

        [ObservableProperty]
        private int? clientSexID;

        [ObservableProperty]
        private string? clientSexDescription;

        [ObservableProperty]
        private string? clientRcode;

        [ObservableProperty]
        private string? clientRegion;

        [ObservableProperty]
        private string? clientProvCode;

        [ObservableProperty]
        private string? clientProvinceName;

        [ObservableProperty]
        private string? clientMunCode;

        [ObservableProperty]
        private string? clientMunicipalities;

        [ObservableProperty]
        private string? clientBcode;

        [ObservableProperty]
        private string? clientBarangayName;

        [ObservableProperty]
        private string? ownershipType;

        [ObservableProperty]
        private string? ownershipTypeDescription;

        [ObservableProperty]
        private string? petName;

        [ObservableProperty]
        private DateTime? petDateofBirth;

        [ObservableProperty]
        private int? petSexID;

        [ObservableProperty]
        private string? petSexDescription;

        [ObservableProperty]
        private int? animalFemaleClassID;

        [ObservableProperty]
        private string? animalFemalClassification;

        [ObservableProperty]
        private int? numberOffspring;

        [ObservableProperty]
        private double? weight;

        [ObservableProperty]
        private double? ageInMonth;

        [ObservableProperty]
        private string? speciesCode;

        [ObservableProperty]
        private string? speciesCommonName;

        [ObservableProperty]
        private string? breedID;

        [ObservableProperty]
        private string? breedDescription;

        [ObservableProperty]
        private string? animalColorID;

        [ObservableProperty]
        private string? animalColorDescription;

        [ObservableProperty]
        private string? petOrigin;

        [ObservableProperty]
        private int? statusID;

        [ObservableProperty]
        private string? statusDescription;

        [ObservableProperty]
        private DateTime? dateDied;

        [ObservableProperty]
        private string? reportOfficer;

        [ObservableProperty]
        private string? petImage1;

        [ObservableProperty]
        private string? petImage2;

        [ObservableProperty]
        private string? petImage3;

        [ObservableProperty]
        private string? petImage4;

        [ObservableProperty]
        private DateTime? dateModified;

        [ObservableProperty]
        private string? userName;

        [ObservableProperty]
        private string? remarks;

        public IAsyncRelayCommand LoadPetRegistrationCommand { get; }

        private async Task LoadPetRegistration()
        {
            try
            {
                var petRegistrations = await clientService.GetPetRegistrationsAsync();
                if (petRegistrations != null)
                {
                    PetRegistrations.Clear();
                    foreach (var pet in petRegistrations)
                    {
                        PetRegistrations.Add(pet);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No pet registration data found.", "OK");
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }

        public async Task RefreshPetRegistrations()
        {
            // Clear the existing collection and reload data
            PetRegistrations.Clear();
            var petRegistrations = await clientService.GetPetRegistrationsAsync();
            if (petRegistrations != null)
            {
                foreach (var pet in petRegistrations)
                {
                    PetRegistrations.Add(pet);
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No pet registration data found.", "OK");
            }
        }
    }
}