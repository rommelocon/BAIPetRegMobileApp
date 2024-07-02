using BAIPetRegMobileApp.Models;
using Newtonsoft.Json;

namespace BAIPetRegMobileApp.Services
{
    public class LoginService : ILoginRepository
    {
        private readonly HttpClient _client;
        private readonly string localhostUrl;

        public LoginService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            _client = new HttpClient(handler);
            localhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7107" : "https://localhost:7107";
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                string requestUrl = $"{localhostUrl}/api/Users/login/{email}/{password}";
                Console.WriteLine($"Request URL: {requestUrl}");

                HttpResponseMessage response = await _client.GetAsync(requestUrl);
                Console.WriteLine($"Response Status Code: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    User? user = JsonConvert.DeserializeObject<User>(content);
                    return user;
                }
                return null;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Network error occurred: {ex.Message}");
                throw new Exception("Network error occurred", ex);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }
    }
}
