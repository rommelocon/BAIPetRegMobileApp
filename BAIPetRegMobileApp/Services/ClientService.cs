using BAIPetRegMobileApp.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;

namespace BAIPetRegMobileApp.Services
{
    public class ClientService
    {
        // Define an event
        public event EventHandler ProfileUpdated;

        // Method to raise the event
        protected virtual void OnProfileUpdated()
        {
            ProfileUpdated?.Invoke(this, EventArgs.Empty);
        }

        private readonly IHttpClientFactory httpClientFactory;

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClientWithAuthorization(string accessToken)
        {
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return httpClient;
        }

        private async Task<LoginResponse?> GetStoredLoginResponseAsync()
        {
            var serializedResponse = await SecureStorage.GetAsync("Authentication");
            return serializedResponse != null ? JsonSerializer.Deserialize<LoginResponse>(serializedResponse) : null;
        }

        private async Task HandleApiResponse(HttpResponseMessage response, string successMessage, string errorMessage)
        {
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Alert", successMessage, "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", errorMessage, "Ok");
            }
        }

        public async Task Login(LoginModel model)
        {
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var result = await httpClient.PostAsJsonAsync("/api/Account/login", model);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<LoginResponse>();

                if (response is not null)
                {
                    var serializedResponse = JsonSerializer.Serialize(response);
                    await SecureStorage.SetAsync("Authentication", serializedResponse);

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
            var loginResponse = await GetStoredLoginResponseAsync();

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                var httpClient = CreateClientWithAuthorization(loginResponse.AccessToken);
                var result = await httpClient.PostAsync("/api/Account/logout", null);
                SecureStorage.Default.Remove("Authentication");
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "Authentication data not found. Please log in.", "Ok");
            }
        }

        public async Task<User?> GetProfile()
        {
            var loginResponse = await GetStoredLoginResponseAsync();

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                var httpClient = CreateClientWithAuthorization(loginResponse.AccessToken);
                var result = await httpClient.GetAsync("/api/Account/user");

                if (result.IsSuccessStatusCode)
                {
                    try
                    {
                        var responseContent = await result.Content.ReadFromJsonAsync<User>();
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
                await Shell.Current.DisplayAlert("Alert", "Authentication data not found. Please log in.", "Ok");
            }

            return null;
        }

        public async Task<HttpResponseMessage> UpdateProfileAsync(User updatedUser)
        {
            var loginResponse = await GetStoredLoginResponseAsync();

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                var httpClient = CreateClientWithAuthorization(loginResponse.AccessToken);
                var response = await httpClient.PutAsJsonAsync("/api/Account/user", updatedUser);

                if (response.IsSuccessStatusCode)
                {
                    OnProfileUpdated();
                }

                return response;
            }

            throw new InvalidOperationException("Authentication data not found.");
        }

        private async Task<List<T>> GetListAsync<T>(string endpoint)
        {
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            
            return JsonSerializer.Deserialize<List<T>>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })!;
        }

        public Task<List<TblRegions>> GetRegionsAsync() => GetListAsync<TblRegions>("/api/Location/regions");
        public Task<List<TblProvinces>> GetProvincesByRegionCodeAsync(string regionCode) => GetListAsync<TblProvinces>($"/api/Location/provinces/{regionCode}");
        public Task<List<TblMunicipalities>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode) => GetListAsync<TblMunicipalities>($"/api/Location/municipalities/{provinceCode}");
        public Task<List<TblBarangays>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode) => GetListAsync<TblBarangays>($"/api/Location/barangays/{municipalityCode}");
        public Task<List<TblSexType>> GetSexType() => GetListAsync<TblSexType>("/api/SexType/sex");
    }
}
