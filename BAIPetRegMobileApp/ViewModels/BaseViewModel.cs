﻿using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        protected readonly ClientService clientService;
        private bool isProfileLoaded;
        [ObservableProperty] private bool isBusy;
        [ObservableProperty] private User? userViewModel;
        [ObservableProperty] private string? userName;
        [ObservableProperty] private string? email;
        [ObservableProperty] private string? firstname;
        [ObservableProperty] private string? lastname;
        [ObservableProperty] private int? civilStatusCode;
        [ObservableProperty] private DateOnly? birthday;
        [ObservableProperty] private int? sexID;
        [ObservableProperty] private string? sexDescription;
        [ObservableProperty] private string? mobileNumber;
        [ObservableProperty] private string? rcodeNum;
        [ObservableProperty] private string? region;
        [ObservableProperty] private string? pcodeNum;
        [ObservableProperty] private string? provinceName;
        [ObservableProperty] private string? mcodeNum;
        [ObservableProperty] private string? municipalitiesCities;
        [ObservableProperty] private string? bcode;
        [ObservableProperty] private string? barangayName;
        [ObservableProperty] private string? middleName;
        [ObservableProperty] private string? extensionName;
        [ObservableProperty] private byte[]? profilePicture;
        [ObservableProperty] private string? fullAddress;
        [ObservableProperty] private string? fullName;
        [ObservableProperty] private string? welcomeMessage;

        public BaseViewModel(ClientService clientService)
        {
            this.clientService = clientService;
        }

        // Method to handle common error display
        protected async Task HandleException(Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }

        // Method to handle common profile loading
        protected async Task LoadProfile(Action<User> updateProperties)
        {
            try
            {
                if (isProfileLoaded) return;

                var serializedResponse = await SecureStorage.GetAsync("Authentication");
                if (serializedResponse != null)
                {
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);

                    if (loginResponse != null)
                    {
                        var user = await clientService.GetProfile();
                        if (user != null)
                        {
                            updateProperties.Invoke(user);
                            isProfileLoaded = true;
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "No profile data found.", "OK");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }

        public async Task InitializeProfileAsync()
        {
            await LoadProfile(user =>
            {
                Firstname = user.Firstname;
                Lastname = user.Lastname;
                MiddleName = user.MiddleName;
                ExtensionName = user.ExtensionName;
                Birthday = user.Birthday;
                SexID = user.SexID;
                SexDescription = user.SexDescription;
                MobileNumber = user.MobileNumber;
                UserName = user.UserName;
                Email = user.Email;
                RcodeNum = user.RcodeNum;
                Region =  user.Region;
                PcodeNum = user.PcodeNum;
                ProvinceName = user.ProvinceName;
                McodeNum = user.McodeNum;
                MunicipalitiesCities = user.MunicipalitiesCities;
                Bcode = user.Bcode;
                BarangayName = user.BarangayName;
                ProfilePicture = user.ProfilePicture;
                FullAddress = user.FullAddress;
                FullName = $"{Firstname} {MiddleName} {Lastname} {ExtensionName}".Trim();
                WelcomeMessage = $"Welcome {(string.IsNullOrEmpty(Firstname) ? UserName : Firstname)}!";
            });
        }
    }
}
