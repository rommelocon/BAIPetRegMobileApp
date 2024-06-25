using BAIPetRegMobileApp.Models;
using BAIPetRegMobileApp.Services;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp;


public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
