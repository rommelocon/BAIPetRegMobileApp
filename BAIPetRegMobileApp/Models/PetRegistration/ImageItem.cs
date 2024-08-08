using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace BAIPetRegMobileApp.Models.PetRegistration
{
    public partial class ImageItem : ObservableObject
    {
        [ObservableProperty]
        private ImageSource? _imageSource;

        [ObservableProperty]
        private string? _fileName;

        [ObservableProperty]
        private string? _fullPath;

        public ICommand? PickImageCommand { get; set; }
    }
}
