using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Views;

public partial class EditProfilePage : ContentPage
{
    private EditProfilePageViewModel viewModel;
    public EditProfilePage(EditProfilePageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }
}