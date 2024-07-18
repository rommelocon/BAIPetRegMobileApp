using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {


        [ObservableProperty]
        private string? userName;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? firstname;

        [ObservableProperty]
        private string? lastname;

        [ObservableProperty]

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


        {
        }
        }


            {
        }
    }
}
