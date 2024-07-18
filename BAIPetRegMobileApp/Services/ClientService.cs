using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;
using System.Text.Json;
using BAIPetRegMobileApp.ViewModels;

namespace BAIPetRegMobileApp.Services;
public class ClientService
{
    private readonly IHttpClientFactory httpClientFactory;

    public ClientService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task Register(RegisterModel model)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var result = await httpClient.PostAsJsonAsync("/register", model);
        if (result.IsSuccessStatusCode)
        {
            await Shell.Current.DisplayAlert("Alert", "Successfully Registered.", "Ok");
        }
        await Shell.Current.DisplayAlert("Alert", result.ReasonPhrase, "Ok");
    }

        public async Task Login(LoginModel model)
        {
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/Account/login", model);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<LoginResponse>();

                if (response is not null)
                {
                    var serializedResponse = JsonSerializer.Serialize(
                        new LoginResponse()
                        {
                            AccessToken = response.AccessToken,
                            RefreshToken = response.RefreshToken,
                            UserName = response.UserName
                        });

                    await SecureStorage.SetAsync("Authentication", serializedResponse);

                    // Navigate to HomePage
                    await Shell.Current.GoToAsync(nameof(HomePage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", "Login failed. Please try again.", "Ok");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Login failed. Please try again.", "Ok");
            }
        }

    public async Task Logout()
    {
        // Retrieve the authentication data from secure storage
        var serializedResponse = await SecureStorage.GetAsync("Authentication");

        if (serializedResponse != null)
        {
            // Deserialize the response to get the username
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
                var result = await httpClient.PostAsync("/Account/logout", null);
                SecureStorage.Default.Remove("Authentication");
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Username is not available. Please log in again.", "Ok");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Alert", "Authentication data not found. Please log in.", "Ok");
        }
    }

    public async Task<UserViewModel> GetProfile()
    {
        // Retrieve the authentication data from secure storage
        var serializedResponse = await SecureStorage.GetAsync("Authentication");

        if (serializedResponse != null)
        {
            // Deserialize the response to get the username
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                // Make the API request with the retrieved username
                var httpClient = httpClientFactory.CreateClient("custom-httpclient");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
                var result = await httpClient.GetAsync($"/Account/profile/{loginResponse.UserName}");

                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadFromJsonAsync<UserViewModel>();
                    try
                    {
                        if (responseContent is not null)
                        {
                            return responseContent;
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Alert", "Failed to retrieve profile data. Please try again.", "Ok");
                        }
                    }
                    catch (JsonException ex)
                    {
                        await Shell.Current.DisplayAlert("Alert", $"Failed to parse profile data: {ex.Message}", "Ok");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", "Failed to retrieve profile. Please try again.", "Ok");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Username is not available. Please log in again.", "Ok");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Alert", "Authentication data not found. Please log in.", "Ok");
        }

        return null;
    }

    public async Task<bool> EditProfile(UserViewModel model)
    {
        // Retrieve the authentication data from secure storage
        var serializedResponse = await SecureStorage.GetAsync("Authentication");

        if (serializedResponse != null)
        {
            // Deserialize the response to get the username and access token
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(serializedResponse);

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                // Make the API request to update the profile
                var httpClient = httpClientFactory.CreateClient("custom-httpclient");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
                var result = await httpClient.PutAsJsonAsync($"/Account/profile/{loginResponse.UserName}", model);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", "Failed to update profile. Please try again.", "Ok");
                    return false;
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Username or access token is not available. Please log in again.", "Ok");
                return false;
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Alert", "Authentication data not found. Please log in.", "Ok");
            return false;
        }
    }
    public async Task<List<TblRegions>> GetRegionOptionsAsync()
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync("api/regions");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if (!string.IsNullOrEmpty(content))
        {
            return JsonSerializer.Deserialize<List<TblRegions>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        return new List<TblRegions>();
    }

    public async Task<IEnumerable<string>> GetProvinceOptionsAsync(string regionCode)
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync($"api/provinces?regionCode={regionCode}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<string>>(json);
    }

    public async Task<IEnumerable<string>> GetMunicipalityOptionsAsync(string provinceCode)
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync($"api/municipalities?provinceCode={provinceCode}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<string>>(json);
    }

    public async Task<IEnumerable<string>> GetBarangayOptionsAsync(string municipalityCode)
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync($"api/barangays?municipalityCode={municipalityCode}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<string>>(json);
    }

    // Methods to get codes based on names
    public async Task<string> GetRegionCodeAsync(string regionName)
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync($"api/regions/code?name={regionName}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<string>(json);
    }

    public async Task<string> GetProvinceCodeAsync(string provinceName)
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync($"api/provinces/code?name={provinceName}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<string>(json);
    }

    public async Task<string> GetMunicipalityCodeAsync(string municipalityName)
    {
        var _httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await _httpClient.GetAsync($"api/municipalities/code?name={municipalityName}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<string>(json);
    }
}