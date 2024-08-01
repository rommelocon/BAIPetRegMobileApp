using BAIPetRegMobileApp.Models.PetRegistration;
using BAIPetRegMobileApp.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Views;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class PetRegisterPageViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;
        private readonly HomePageViewModel viewModel;

        public PetRegisterPageViewModel(ClientService clientService, HomePageViewModel viewModel) : base(clientService)
        {
            _clientService = clientService;
            this.viewModel = viewModel;

            // Initialize collections
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

            // Load initial data
            LoadDataCommand.ExecuteAsync(null);
            this.viewModel = viewModel;
        }

        // Properties
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

        // Observable properties
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
        private TagType _selectedTagType;

        [ObservableProperty]
        private PetRegistration _petRegistration = new PetRegistration();

        [ObservableProperty]
        private bool _isTagNumberVisible;  // Visibility for Tag Number entry

        // Handle tag type selection change
        partial void OnSelectedTagTypeChanged(TagType value)
        {
            IsTagNumberVisible = value != null && value.TagID != "NO";
        }

        partial void OnSelectedSpeciesGroupChanged(SpeciesGroup value)
        {
            if (value != null)
            {
                LoadBreedsAsync(value.SpeciesCode!);
            }
        }

        private async void LoadBreedsAsync(string speciesCode)
        {
            try
            {
                SpeciesBreeds.Clear();
                var speciesBreeds = await _clientService.GetSpeciesBreedsAsync(speciesCode);
                foreach (var breed in speciesBreeds)
                {
                    SpeciesBreeds.Add(breed);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An error occurred while loading breeds: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                // Load various types of data from the client service
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

                TagTypes.Clear();
                var tagTypes = await _clientService.GetTagTypesAsync();
                foreach (var item in tagTypes)
                    TagTypes.Add(item);

                SpeciesGroups.Clear();
                var speciesGroups = await _clientService.GetSpeciesGroupsAsync();
                foreach (var item in speciesGroups)
                    SpeciesGroups.Add(item);

                SexTypes.Clear();
                var sexTypes = await _clientService.GetSexType();
                foreach (var item in sexTypes)
                    SexTypes.Add(item);
            }
            catch (Exception ex)
            {
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
            // Create your PetRegistration object and populate it
            var petRegistration = new PetRegistration
            {
                DateRegistered = DateTime.Now,
                DateEncocde = DateTime.Now,
                PetName = PetRegistration.PetName,
                Weight = PetRegistration.Weight,
                OwnershipType = SelectedOwnerShipType.OwnerShipTypeID,
                OwnershipTypeDescription = SelectedOwnerShipType.OwnerShipDescription,
                SpeciesCode = SelectedSpeciesGroup.SpeciesCode,
                SpeciesCommonName = SelectedSpeciesGroup.SpeciesCommonName,
                BreedID = SelectedSpeciesBreed.BreedID,
                BreedDescription= SelectedSpeciesBreed.BreedDescription,
                PetSexID = SelectedSexType.SexID,
                PetSexDescription = SelectedSexType.SexDescription,
                TagID = SelectedTagType.TagID,
                TagDescription = SelectedTagType.TagDescription,
                TagNo = PetRegistration.TagNo,
                AnimalColorDescription = SelectedAnimalColor.AnimalColorDescription,
                AnimalColorID = SelectedAnimalColor.AnimalColorID,
                PetDateofBirth = this.PetRegistration.PetDateofBirth,
            };

            // Call your API to submit the registration
            await clientService.RegisterPetAsync(petRegistration);

            // Refresh the pet registrations collection
            await viewModel.RefreshPetRegistrations();

            await Shell.Current.DisplayAlert("Alert", "Succesfully Registered.", "Ok");
            await Shell.Current.GoToAsync(nameof(FinalCheckingPage));
        }


    }
}
