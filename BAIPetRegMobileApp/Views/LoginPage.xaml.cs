using System.Security.Cryptography;
using System.Text;

namespace BAIPetRegMobileApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            Application.Current.Quit();
            return true;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (IsCredentialCorrect(UsernameEntry.Text, PasswordEntry.Text))
            {
                await SecureStorage.SetAsync("hasAuth", "true");
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            else
            {
                await DisplayAlert("Login failed", "Username or password is invalid", "Try again");
                UsernameEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;

            }
        }

        bool IsCredentialCorrect(string username, string password)
        {
            // Hash the input password
            var hashedInputPassword = HashPassword(password);

            // Compare the hashed input password with the stored hashed password
            return username == "admin" && password == "1234";
        }

        string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private async void ClickableLabel_Tapped(object sender, TappedEventArgs e)
        {
            string url = "https://www.bai.gov.ph/Admin/Account/ClientRegistration";

            await Launcher.OpenAsync(url);
        }

        private async void ForgotPasswordLabel_Tapped(object sender, TappedEventArgs e)
        {
            string url = "https://www.bai.gov.ph/Admin/Account/Forgot";

            await Launcher.OpenAsync(url);
        }

    }
}
