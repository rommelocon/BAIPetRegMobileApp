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
        private readonly HomePageViewModel _viewModel;

        public PetRegisterPageViewModel(ClientService clientService, HomePageViewModel viewModel)
            : base(clientService)
        {
            _viewModel = viewModel;
            LoadDataCommand.ExecuteAsync(null);
            InitializeCollections();
            // Initialize with empty image items
            for (int i = 0; i < 4; i++)
            {
                var imageItem = new ImageItem();
                imageItem.PickImageCommand = new RelayCommand(async () => await PickImageAsync(imageItem));
                ImageItems.Add(imageItem);
            }
        }

        // Properties
        public ObservableCollection<OwnerShipType> OwnerShipTypes { get; } = new ObservableCollection<OwnerShipType>();
        public ObservableCollection<AnimalColor> AnimalColors { get; } = new ObservableCollection<AnimalColor>();
        public ObservableCollection<AnimalContact> AnimalContacts { get; } = new ObservableCollection<AnimalContact>();
        public ObservableCollection<AnimalFemaleClassification> AnimalFemaleClassifications { get; } = new ObservableCollection<AnimalFemaleClassification>();
        public ObservableCollection<PetTagType> PetTagTypes { get; } = new ObservableCollection<PetTagType>();
        public ObservableCollection<SpeciesBreed> SpeciesBreeds { get; } = new ObservableCollection<SpeciesBreed>();
        public ObservableCollection<SpeciesGroup> SpeciesGroups { get; } = new ObservableCollection<SpeciesGroup>();
        public ObservableCollection<TagType> TagTypes { get; } = new ObservableCollection<TagType>();
        public ObservableCollection<SexType> SexTypes { get; } = new ObservableCollection<SexType>();
        public ObservableCollection<ImageItem> ImageItems { get; } = new ObservableCollection<ImageItem>();

        [ObservableProperty] private string _selectedImage1;
        [ObservableProperty] private string _selectedImage2;
        [ObservableProperty] private string _selectedImage3;
        [ObservableProperty] private string _selectedImage4;
        [ObservableProperty] private DateTime? _maximumDate = DateTime.Today;
        [ObservableProperty] private DateTime? _selectedPetDateofBirth;
        [ObservableProperty] private SpeciesGroup _selectedSpeciesGroup;
        [ObservableProperty] private OwnerShipType _selectedOwnerShipType;
        [ObservableProperty] private SpeciesBreed _selectedSpeciesBreed;
        [ObservableProperty] private SexType _selectedSexType;
        [ObservableProperty] private AnimalContact _selectedAnimalContact;
        [ObservableProperty] private AnimalColor _selectedAnimalColor;
        [ObservableProperty] private AnimalFemaleClassification _selectedAnimalFemaleClassification;
        [ObservableProperty] private PetTagType _selectedPetTagType;
        [ObservableProperty] private TagType _selectedTagType;
        [ObservableProperty] private PetRegistration _petRegistration = new();
        [ObservableProperty] private bool _isTagNumberVisible;

        public bool IsFemaleSelected => SelectedSexType?.SexID == 2;
        public bool IsLactatingSelected => SelectedAnimalFemaleClassification?.AnimalFemaleClassID == 2;


        private void InitializeCollections()
        {
            PetRegistrations = new ObservableCollection<PetRegistration>();
        }
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
                IsBusy = true;
                SpeciesBreeds.Clear();
                var breeds = await clientService.GetSpeciesBreedsAsync(speciesCode);
                foreach (var breed in breeds)
                {
                    SpeciesBreeds.Add(breed);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                await Task.WhenAll(
                    LoadCollectionAsync(() => clientService.GetOwnerShipTypes(), OwnerShipTypes),
                    LoadCollectionAsync(() => clientService.GetAnimalColors(), AnimalColors),
                    LoadCollectionAsync(() => clientService.GetAnimalContactsAsync(), AnimalContacts),
                    LoadCollectionAsync(() => clientService.GetAnimalFemaleClassificationsAsync(), AnimalFemaleClassifications),
                    LoadCollectionAsync(() => clientService.GetTagTypesAsync(), TagTypes),
                    LoadCollectionAsync(() => clientService.GetSpeciesGroupsAsync(), SpeciesGroups),
                    LoadCollectionAsync(() => clientService.GetSexType(), SexTypes)
                );
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task PetRegistrationSubmit()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var uploadFileNames = new List<string>();
                foreach (var imageItem in ImageItems)
                {
                    if (!string.IsNullOrEmpty(imageItem.FileName))
                    {
                        using (var stream = File.OpenRead(imageItem.FullPath))
                        using (var content = new MultipartFormDataContent())
                        {
                            content.Add(new StreamContent(stream), "file", imageItem.FileName);
                            var responseImage = await clientService.UploadImageAsync(content);

                            if (responseImage.IsSuccessStatusCode)
                            {
                                var uploadedFileName = await responseImage.Content.ReadAsStringAsync();
                                uploadFileNames.Add(uploadedFileName);
                            }
                            else
                            {
                                // Handle the error (e.g., show a message to the user)
                                await Shell.Current.DisplayAlert("Error", "Image upload failed.", "Ok");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            finally { IsBusy = false; }

            var petRegistration = new PetRegistration
            {
                DateRegistered = DateTime.Now,
                DateEncocde = DateTime.Now,
                PetName = PetRegistration.PetName,
                Weight = PetRegistration.Weight,
                OwnershipType = SelectedOwnerShipType?.OwnerShipTypeID,
                OwnershipTypeDescription = SelectedOwnerShipType?.OwnerShipDescription,
                SpeciesCode = SelectedSpeciesGroup?.SpeciesCode,
                SpeciesCommonName = SelectedSpeciesGroup?.SpeciesCommonName,
                BreedID = SelectedSpeciesBreed?.BreedID,
                BreedDescription = SelectedSpeciesBreed?.BreedDescription,
                PetSexID = SelectedSexType?.SexID,
                PetSexDescription = SelectedSexType?.SexDescription,
                TagID = SelectedTagType?.TagID,
                TagDescription = SelectedTagType?.TagDescription,
                TagNo = PetRegistration.TagNo,
                AnimalColorDescription = SelectedAnimalColor?.AnimalColorDescription,
                AnimalColorID = SelectedAnimalColor?.AnimalColorID,
                PetDateofBirth = SelectedPetDateofBirth,
                AnimalFemalClassification = PetRegistration.AnimalFemalClassification,
                AnimalFemaleClassID = PetRegistration.AnimalFemaleClassID,
                NumberOffspring = PetRegistration.NumberOffspring,
                PetImage1 = ImageItems[0].FileName,
                PetImage2 = ImageItems[1].FileName,
                PetImage3 = ImageItems[2].FileName,
                PetImage4 = ImageItems[3].FileName,
                PetOrigin = PetRegistration.PetOrigin,
                Remarks = PetRegistration.Remarks,
                Alias = PetRegistration.Alias
            };

            var response = await clientService.RegisterPetAsync(petRegistration);
            if (response)
            {
                await Shell.Current.DisplayAlert("Alert", "Successfully Registered.", "Ok");
                // Refresh homepage
                await _viewModel.RefreshPetRegistrationsAsync();
                ClearAllFields();
                await Shell.Current.GoToAsync(nameof(FinalCheckingPage));
            }
        }

        private void ClearAllFields()
        {
            PetRegistration = new PetRegistration();
            SelectedOwnerShipType = null;
            SelectedSpeciesGroup = null;
            SelectedSpeciesBreed = null;
            SelectedSexType = null;
            SelectedAnimalContact = null;
            SelectedAnimalColor = null;
            SelectedAnimalFemaleClassification = null;
            SelectedPetTagType = null;
            SelectedTagType = null;
            IsTagNumberVisible = false;
            SpeciesBreeds.Clear();
            ImageItems.Clear();
        }

        [RelayCommand]
        private async Task PickImage1Async() => await PickImageAsync(ImageItems[0]);

        [RelayCommand]
        private async Task PickImage2Async() => await PickImageAsync(ImageItems[1]);

        [RelayCommand]
        private async Task PickImage3Async() => await PickImageAsync(ImageItems[2]);

        [RelayCommand]
        private async Task PickImage4Async() => await PickImageAsync(ImageItems[3]);

        private async Task PickImageAsync(ImageItem imageItem)
        {
            var uploadFile = await MediaPicker.PickPhotoAsync();
            if (uploadFile is null) return;

            // Get the original file extension
            var extension = Path.GetExtension(uploadFile.FileName);

            // Generate a random filename
            var randomFilename = GenerateRandomFilename(extension);

            var stream = await uploadFile.OpenReadAsync();

            imageItem.ImageSource = ImageSource.FromStream(() => stream);
            imageItem.FileName = randomFilename;
            imageItem.FullPath = uploadFile.FullPath;

            // Update the corresponding SelectedImage property
            int index = ImageItems.IndexOf(imageItem);
            switch (index)
            {
                case 0:
                    SelectedImage1 = uploadFile.FullPath;
                    break;
                case 1:
                    SelectedImage2 = uploadFile.FullPath;
                    break;
                case 2:
                    SelectedImage3 = uploadFile.FullPath;
                    break;
                case 3:
                    SelectedImage4 = uploadFile.FullPath;
                    break;
            }
        }

        string GenerateRandomFilename(string extension)
        {
            return $"{Guid.NewGuid()}{extension}";
        }
    }
}
