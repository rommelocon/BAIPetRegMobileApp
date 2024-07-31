using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using BAIPetRegMobileApp.Models.User;
using System.Threading.Tasks;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class PetRegisterPageViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;

        public PetRegisterPageViewModel(ClientService clientService) : base(clientService)
        {
            _clientService = clientService;

            PetRegistrations = new ObservableCollection<PetRegistration>();
            OwnerShipTypes = new ObservableCollection<OwnerShipType>();
            AnimalColors = new ObservableCollection<AnimalColor>();
            AnimalContacts = new ObservableCollection<AnimalContact>();
            AnimalFemaleClassifications = new ObservableCollection<AnimalFemaleClassification>();
            PetTagTypes = new ObservableCollection<PetTagType>();
            SpeciesBreeds = new ObservableCollection<SpeciesBreed>();
            SpeciesGroups = new ObservableCollection<SpeciesGroup>();
            TagTypes = new ObservableCollection<TagType>();
            SexTypes = new ObservableCollection<SexType>();

            LoadDataCommand.ExecuteAsync(null);
        }

        public ObservableCollection<PetRegistration> PetRegistrations { get; }
        public ObservableCollection<OwnerShipType> OwnerShipTypes { get; }
        public ObservableCollection<AnimalColor> AnimalColors { get; }
        public ObservableCollection<AnimalContact> AnimalContacts { get; }
        public ObservableCollection<AnimalFemaleClassification> AnimalFemaleClassifications { get; }
        public ObservableCollection<PetTagType> PetTagTypes { get; }
        public ObservableCollection<SpeciesBreed> SpeciesBreeds { get; }
        public ObservableCollection<SpeciesGroup> SpeciesGroups { get; }
        public ObservableCollection<TagType> TagTypes { get; }
        public ObservableCollection<SexType> SexTypes { get; }

        [ObservableProperty]
        private SpeciesGroup _selectedSpeciesGroup;

        [ObservableProperty]
        private OwnerShipType _selectedOwnerShipType;

        [ObservableProperty]
        private SpeciesBreed _selectedSpeciesBreed;

        [ObservableProperty]
        private SexType _selectedSexType;

        [ObservableProperty]
        private AnimalContact _selectedAnimalContact;

        [ObservableProperty]
        private AnimalColor _selectedAnimalColor;

        [ObservableProperty]
        private PetTagType _selectedPetTagType;

        [ObservableProperty]
        private PetRegistration _petRegistration = new PetRegistration();

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                OwnerShipTypes.Clear();
                var ownershipTypes = await _clientService.GetOwnerShipTypes();
                foreach (var item in ownershipTypes)
                    OwnerShipTypes.Add(item);

                AnimalColors.Clear();
                var animalColors = await _clientService.GetAnimalColors();
                foreach (var item in animalColors)
                    AnimalColors.Add(item);

                AnimalContacts.Clear();
                var animalContacts = await _clientService.GetAnimalContactsAsync();
                foreach (var item in animalContacts)
                    AnimalContacts.Add(item);

                AnimalFemaleClassifications.Clear();
                var animalFemaleClassifications = await _clientService.GetAnimalFemaleClassificationsAsync();
                foreach (var item in animalFemaleClassifications)
                    AnimalFemaleClassifications.Add(item);

                PetTagTypes.Clear();
                var petTagTypes = await _clientService.GetPetTagTypesAsync();
                foreach (var item in petTagTypes)
                    PetTagTypes.Add(item);

                SpeciesGroups.Clear();
                var speciesGroups = await _clientService.GetSpeciesGroupsAsync();
                foreach (var item in speciesGroups)
                    SpeciesGroups.Add(item);

                if (_selectedSpeciesGroup != null)
                {
                    SpeciesBreeds.Clear();
                    var speciesBreeds = await _clientService.GetSpeciesBreedsAsync(_selectedSpeciesGroup.SpeciesCode);
                    foreach (var item in speciesBreeds)
                        SpeciesBreeds.Add(item);
                }

                TagTypes.Clear();
                var tagTypes = await _clientService.GetTagTypesAsync();
                foreach (var item in tagTypes)
                    TagTypes.Add(item);

                SexTypes.Clear();
                var sexTypes = await _clientService.GetSexType();
                foreach (var item in sexTypes)
                    SexTypes.Add(item);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., logging, user notifications)
                await Shell.Current.DisplayAlert("Error", $"An error occurred while loading data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task PetRegistrationSubmit()
        {
            if (PetRegistration == null)
            {
                await Shell.Current.DisplayAlert("Error", "Pet registration details are missing.", "OK");
                return;
            }

            try
            {
                var response = await _clientService.RegisterPetAsync(PetRegistration);
                await Shell.Current.DisplayAlert("Success", response, "OK");
            }
            catch (Exception ex)
            {
                // Handle error
                await Shell.Current.DisplayAlert("Error", $"An error occurred while registering the pet: {ex.Message}", "OK");
            }
        }
    }
}
