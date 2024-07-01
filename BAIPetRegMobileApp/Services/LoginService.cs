using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace BAIPetRegMobileApp.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                };
                var client = new HttpClient(handler);

                var localhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7107" : "https://localhost:7107";
                string requestUrl = $"{localhostUrl}/api/Users/login/{email}/{password}";
                client.BaseAddress = new Uri(requestUrl);
                Console.WriteLine($"Request URL: {requestUrl}");

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                Console.WriteLine($"Response Status Code: {response.StatusCode}");

                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Content: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        User user = await response.Content.ReadFromJsonAsync<User>();
                        Console.WriteLine($"User retrieved: {user}");
                        return user;
                    }
                    catch (Exception jsonEx)
                    {
                        Console.WriteLine($"Failed to parse JSON: {jsonEx.Message}");
                        throw new Exception("Failed to parse JSON response", jsonEx);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    Console.WriteLine("Login failed: No content returned");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Login failed with status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Network error occurred: {ex.Message}");
                throw new Exception("Network error occurred", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the login process: {ex.Message}");
                throw new Exception("An error occurred during the login process", ex);
            }
        }
    }
}
