using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;

namespace BAIPetRegMobileApp.Services;
public class LoginService : ILoginRepository
{
    public async Task<User?> Login(string email, string password)
    {
        try
        {
            var client = new HttpClient();
            string localhostUrl = "https://localhost:7107/api/user/login/" + email + "/" + password;
            HttpResponseMessage response = await client.GetAsync(localhostUrl);
            if (response.IsSuccessStatusCode)
            {
                User? user = await response.Content.ReadFromJsonAsync<User>();
                return user;
            }
            return null;
        }

        catch(Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            return null;
        }
    }
}
