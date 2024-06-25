using Newtonsoft.Json;
using System.Text;

namespace BAIPetRegMobileApp;


public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
