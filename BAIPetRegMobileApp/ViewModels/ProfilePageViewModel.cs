using CommunityToolkit.Mvvm.ComponentModel;

namespace BAIPetRegMobileApp.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string profilePicture;

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string role;

        [ObservableProperty]
        private int registeredDogs;

        [ObservableProperty]
        private int registeredCats;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string civilStatus;

        [ObservableProperty]
        private string birthday;

        [ObservableProperty]
        private string sex;

        [ObservableProperty]
        private string contactNumber;

        [ObservableProperty]
        private string nationality;

        [ObservableProperty]
        private string region;

        [ObservableProperty]
        private string province;

        [ObservableProperty]
        private string municipality;

        [ObservableProperty]
        private string barangay;

        [ObservableProperty]
        private string street;
        public ProfilePageViewModel() 
        {
          
        }
    }
}
