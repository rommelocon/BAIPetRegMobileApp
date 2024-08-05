using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace BAIPetRegMobileApp.Models.PetRegistration
{
    public class ImageItem : ObservableObject
    {
        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        private string _fullPath;
        public string FullPath
        {
            get => _fullPath;
            set => SetProperty(ref _fullPath, value);
        }

        public ICommand PickImageCommand { get; set; }
    }
}
