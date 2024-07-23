using BAIPetRegMobileApp.ViewModels;
using CommunityToolkit.Mvvm.Input;

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
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.InitializeProfileAsync();
    }

    private async Task SaveProfileAsync()
    {
        await viewModel.SaveProfile();
    }
}