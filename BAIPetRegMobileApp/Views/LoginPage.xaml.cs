using Newtonsoft.Json;
using System.Text;

namespace BAIPetRegMobileApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void OnLoginButton_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(HomePage));
    }
}
