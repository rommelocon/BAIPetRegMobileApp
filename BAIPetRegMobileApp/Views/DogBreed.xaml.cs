using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views
{
    public partial class DogBreed : ContentPage
    {
        private DogBreedViewModel ViewModel => BindingContext as DogBreedViewModel;

        public DogBreed()
        {
            InitializeComponent();
            BindingContext = new DogBreedViewModel();
        }

        private void MenuBtnClicked_Clicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }

        private void HomepageBtn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(HomePage));
        }
    }
}