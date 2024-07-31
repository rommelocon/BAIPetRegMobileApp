using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;
using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Models.PetRegistration;

namespace BAIPetRegMobileApp.Services
{
    public class ClientService
    {
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

                return response;
            }

            throw new InvalidOperationException("Authentication data not found.");
        }

        public async Task<bool> RegisterPetAsync(PetRegistration model)
        {
            var loginResponse = await GetStoredLoginResponseAsync();

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                var httpClient = CreateClientWithAuthorization(loginResponse.AccessToken);
                var response = await httpClient.PostAsJsonAsync("/api/PetRegistration/register", model);
                return response.IsSuccessStatusCode;
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

        public Task<List<Regions>> GetRegionsAsync() => GetListAsync<Regions>("/api/Location/regions");
        public Task<List<Provinces>> GetProvincesByRegionCodeAsync(string regionCode) => GetListAsync<Provinces>($"/api/Location/provinces/{regionCode}");
        public Task<List<Municipalities>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode) => GetListAsync<Municipalities>($"/api/Location/municipalities/{provinceCode}");
        public Task<List<Barangays>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode) => GetListAsync<Barangays>($"/api/Location/barangays/{municipalityCode}");
        public Task<List<SexType>> GetSexType() => GetListAsync<SexType>("/api/SexType/sex");
        public Task<List<OwnerShipType>> GetOwnerShipTypes() => GetListAsync<OwnerShipType>("/api/PetRegistration/ownershipType");
        public Task<List<AnimalColor>> GetAnimalColors() => GetListAsync<AnimalColor>("/api/PetRegistration/animalColor");
        public Task<List<AnimalContact>> GetAnimalContactsAsync() => GetListAsync<AnimalContact>("/api/PetRegistration/animalContacts");
        public Task<List<AnimalFemaleClassification>> GetAnimalFemaleClassificationsAsync() => GetListAsync<AnimalFemaleClassification>("/api/PetRegistration/animalFemaleClassificator");
        public Task<List<PetTagType>> GetPetTagTypesAsync() => GetListAsync<PetTagType>("/api/PetRegistration/petTagType");
        public Task<List<SpeciesBreed>> GetSpeciesBreedsAsync(string speciesCode) => GetListAsync<SpeciesBreed>($"/api/PetRegistration/speciesBreed/{speciesCode}");
        public Task<List<SpeciesGroup>> GetSpeciesGroupsAsync() => GetListAsync<SpeciesGroup>("/api/PetRegistration/speciesGroup");
        public Task<List<TagType>> GetTagTypesAsync() => GetListAsync<TagType>("/api/PetRegistration/tagType");
    }
}
