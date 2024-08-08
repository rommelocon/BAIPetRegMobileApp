using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class CatBreed : ContentPage
{
    private CatBreedViewModel viewModel => BindingContext as CatBreedViewModel;
    public CatBreed()
    {
        InitializeComponent();
        BindingContext = new CatBreedViewModel();
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