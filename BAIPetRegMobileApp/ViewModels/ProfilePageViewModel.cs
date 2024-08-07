using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class ProfilePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private int dogCount;

        [ObservableProperty]
        private int catCount;

        public ProfilePageViewModel(ClientService clientService) : base(clientService)
        {
            InitializeProfilePage();
            _ = LoadPetCountsAsync();
        }

        private async void InitializeProfilePage()
        {
            UserData = await clientService.GetProfile();
        }
        private async Task LoadPetCountsAsync()
        {
            try
            {
                var pets = await clientService.GetPetRegistrationsAsync();
                if (pets != null)
                {
                    DogCount = pets.Count(pet => pet.SpeciesCommonName == "Dog");
                    CatCount = pets.Count(pet => pet.SpeciesCommonName == "Cat");
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }

        [RelayCommand]
        private async Task EditProfileButton()
        {
            await Shell.Current.GoToAsync(nameof(EditProfilePage));
        }
    }
}
