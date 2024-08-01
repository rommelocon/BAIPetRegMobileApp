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
        private readonly HomePageViewModel _viewModel;

        public PetRegisterPageViewModel(ClientService clientService, HomePageViewModel viewModel) : base(clientService)
        {
            _clientService = clientService;
            _viewModel = viewModel;
            InitializeCollections();
            LoadDataCommand.ExecuteAsync(null);
        }

        // Properties
        public ObservableCollection<PetRegistration> PetRegistrations { get; private set; }
        public ObservableCollection<OwnerShipType> OwnerShipTypes { get; private set; }
        public ObservableCollection<AnimalColor> AnimalColors { get; private set; }
        public ObservableCollection<AnimalContact> AnimalContacts { get; private set; }
        public ObservableCollection<AnimalFemaleClassification> AnimalFemaleClassifications { get; private set; }
        public ObservableCollection<PetTagType> PetTagTypes { get; private set; }
        public ObservableCollection<SpeciesBreed> SpeciesBreeds { get; private set; }
        public ObservableCollection<SpeciesGroup> SpeciesGroups { get; private set; }
        public ObservableCollection<TagType> TagTypes { get; private set; }
        public ObservableCollection<SexType> SexTypes { get; private set; }

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
        private AnimalFemaleClassification _selectedAnimalFemaleClassification;

        [ObservableProperty]
        private PetTagType _selectedPetTagType;

        [ObservableProperty]
        private TagType _selectedTagType;

        [ObservableProperty]
        private PetRegistration _petRegistration = new();

        [ObservableProperty]
        private bool _isTagNumberVisible;

        [RelayCommand]
        public async Task RefreshPetRegistrations()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var petRegistrations = await _clientService.GetPetRegistrationsAsync();
                // Update your observable collection or other properties
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An error occurred while refreshing data: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public bool IsFemaleSelected => SelectedSexType?.SexID == 2;
        public bool IsLactatingSelected => SelectedAnimalFemaleClassification?.AnimalFemaleClassID == 2;

        partial void OnSelectedAnimalFemaleClassificationChanged(AnimalFemaleClassification value)
        {
            OnPropertyChanged(nameof(IsLactatingSelected));
        }

        partial void OnSelectedSexTypeChanged(SexType value)
        {
            OnPropertyChanged(nameof(IsFemaleSelected));
        }

        partial void OnSelectedTagTypeChanged(TagType value)
        {
            IsTagNumberVisible = value?.TagID != "NO";
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

                await LoadCollectionAsync(() => _clientService.GetOwnerShipTypes(), OwnerShipTypes);
                await LoadCollectionAsync(() => _clientService.GetAnimalColors(), AnimalColors);
                await LoadCollectionAsync(() => _clientService.GetAnimalContactsAsync(), AnimalContacts);
                await LoadCollectionAsync(() => _clientService.GetAnimalFemaleClassificationsAsync(), AnimalFemaleClassifications);
                await LoadCollectionAsync(() => _clientService.GetTagTypesAsync(), TagTypes);
                await LoadCollectionAsync(() => _clientService.GetSpeciesGroupsAsync(), SpeciesGroups);
                await LoadCollectionAsync(() => _clientService.GetSexType(), SexTypes);
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
                BreedDescription = SelectedSpeciesBreed.BreedDescription,
                PetSexID = SelectedSexType.SexID,
                PetSexDescription = SelectedSexType.SexDescription,
                TagID = SelectedTagType.TagID,
                TagDescription = SelectedTagType.TagDescription,
                TagNo = PetRegistration.TagNo,
                AnimalColorDescription = SelectedAnimalColor.AnimalColorDescription,
                AnimalColorID = SelectedAnimalColor.AnimalColorID,
                PetDateofBirth = PetRegistration.PetDateofBirth,
                AnimalFemalClassification = PetRegistration.AnimalFemalClassification,
                AnimalFemaleClassID = PetRegistration.AnimalFemaleClassID,
                NumberOffspring = PetRegistration.NumberOffspring,
                PetImage1 = PetRegistration.PetImage1,
                PetImage2 = PetRegistration.PetImage2,
                PetImage3 = PetRegistration.PetImage3,
                PetImage4 = PetRegistration.PetImage4,
                PetOrigin = PetRegistration.PetOrigin,
                Remarks = PetRegistration.Remarks,
                Alias = PetRegistration.Alias,
            };

            await _clientService.RegisterPetAsync(petRegistration);
            await Shell.Current.DisplayAlert("Alert", "Successfully Registered.", "Ok");

            // Refresh HomePageViewModel
            await RefreshPetRegistrations();

            // Navigate to the final checking page
            await Shell.Current.GoToAsync(nameof(FinalCheckingPage));
        }

        private void InitializeCollections()
        {
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
        }

      

    }
}
