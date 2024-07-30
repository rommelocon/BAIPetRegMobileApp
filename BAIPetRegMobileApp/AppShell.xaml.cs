﻿using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.Views;
using CommunityToolkit.Mvvm.Input;

namespace BAIPetRegMobileApp
{
    public partial class AppShell : Shell
    {
        private readonly ClientService clientService;
        public AppShell(ClientService clientService)
        {
            InitializeComponent();
            this.clientService = clientService;
            BindingContext = clientService;
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(FinalCheckingPage), typeof(FinalCheckingPage));
            Routing.RegisterRoute(nameof(PetRegisterPage), typeof(PetRegisterPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(PetInformationPage), typeof(PetInformationPage));
            Routing.RegisterRoute(nameof(CatBreedPage), typeof(CatBreedPage));
            Routing.RegisterRoute(nameof(DogBreedPage), typeof(DogBreedPage));
            Routing.RegisterRoute(nameof(TOAPage), typeof(TOAPage));
            Routing.RegisterRoute(nameof(EditProfilePage), typeof(EditProfilePage));
        }

        private void ClostMenuButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
        }

        private void PetRegisterBtn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(PetRegisterPage));
            Shell.Current.FlyoutIsPresented = false;
        }

        private void OnProfileButtonTapped(object sender, TappedEventArgs e)
        {
            Shell.Current.GoToAsync(nameof(ProfilePage));
            Shell.Current.FlyoutIsPresented = false;
        }

        private void OnRegisterPetButtonTapped(object sender, TappedEventArgs e)
        {
            Shell.Current.GoToAsync(nameof(PetRegisterPage));
            Shell.Current.FlyoutIsPresented = false;

        }

        private void OnDogPetButtonTapped(object sender, TappedEventArgs e)
        {
            Shell.Current.GoToAsync(nameof(DogBreedPage));
            Shell.Current.FlyoutIsPresented = false;
        }

        private void OnCatPetButtonTapped(object sender, TappedEventArgs e)
        {
            Shell.Current.GoToAsync(nameof(CatBreedPage));
            Shell.Current.FlyoutIsPresented = false;
        }

        [RelayCommand]
        public async Task Logout()
        {
            try
            {
                await clientService.Logout();
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            catch (Exception ex)
            {
                // Handle the exception (logging, showing message, etc.)
                await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}