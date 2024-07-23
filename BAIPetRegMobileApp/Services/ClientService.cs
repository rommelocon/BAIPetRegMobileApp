using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;
using System.Text.Json;
using BAIPetRegMobileApp.ViewModels;
using System.Text;

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

    public async Task<UserViewModel?> GetProfile()
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

    public async Task<bool> SaveProfile(UserViewModel model)
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

                var userToUpdate = new UserViewModel
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    MiddleName = model.MiddleName,
                    ExtensionName = model.ExtensionName,
                    Birthday = model.Birthday,
                    SexDescription = model.SexDescription,
                    Email = model.Email,
                    CivilStatusName = model.CivilStatusName,
                    MobileNumber = model.MobileNumber,
                    Region = model.Region,
                    ProvinceName = model.ProvinceName,
                    MunicipalitiesCities = model.MunicipalitiesCities,
                    BarangayName = model.BarangayName,
                    StreetNumber = model.StreetNumber
                    // Add other properties as needed
                };

                var json = JsonSerializer.Serialize(userToUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"/Account/profile/{loginResponse.UserName}", content);
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadFromJsonAsync<UserViewModel>();
                }

            }
        }
        return false;
    }
    public async Task<List<TblRegions>> GetRegionsAsync()
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await httpClient.GetAsync("api/Regions");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var regions = JsonSerializer.Deserialize<List<TblRegions>>(jsonResponse, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return regions;
    }
    public async Task<List<TblProvinces>> GetProvincesByRegionCodeAsync(string regionCode)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await httpClient.GetStringAsync($"api/Provinces/by-region/{regionCode}");
        var provinces = JsonSerializer.Deserialize<List<TblProvinces>>(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return provinces;
    }

    public async Task<List<TblMunicipalities>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await httpClient.GetStringAsync($"api/Municipalities/by-province/{provinceCode}");
        var municipalities = JsonSerializer.Deserialize<List<TblMunicipalities>>(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return municipalities;
    }

    public async Task<List<TblBarangays>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode)
    {
        var httpClient = httpClientFactory.CreateClient("custom-httpclient");
        var response = await httpClient.GetStringAsync($"api/Barangays/by-municipality/{municipalityCode}");
        var barangays = JsonSerializer.Deserialize<List<TblBarangays>>(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return barangays;
    }
}