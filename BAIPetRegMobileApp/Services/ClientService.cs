using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http.Headers;
using BAIPetRegMobileApp.Models.User;
using BAIPetRegMobileApp.Models.PetRegistration;
using System.Net;

namespace BAIPetRegMobileApp.Services
{
    public class ClientService(IHttpClientFactory httpClientFactory)
    {
        private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

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
                await httpClient.PostAsync("/api/Account/logout", null);
                SecureStorage.Default.Remove("Authentication");
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
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            throw new InvalidOperationException("Authentication data not found.");
        }

        public async Task<IEnumerable<PetRegistration>> GetPetRegistrationsAsync()
        {
            var loginResponse = await GetStoredLoginResponseAsync();
            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                var httpClient = CreateClientWithAuthorization(loginResponse.AccessToken);
                var response = await httpClient.GetAsync("/api/PetRegistration");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    var petRegistrations = JsonSerializer.Deserialize<List<PetRegistration>>(content, options);
                    return petRegistrations ?? Enumerable.Empty<PetRegistration>();
                }
                return Enumerable.Empty<PetRegistration>();
            }
            throw new InvalidOperationException("Authentication data not found.");
        }

        public async Task<PetRegistration?> GetPetRegistrationByIdAsync(string id)
        {
            var loginResponse = await GetStoredLoginResponseAsync();
            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.UserName) && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                var httpClient = CreateClientWithAuthorization(loginResponse.AccessToken);
                var response = await httpClient.GetAsync($"/api/PetRegistration/{id}"); // Ensure this endpoint returns a single PetRegistration object
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    try
                    {
                        // Deserialize JSON array
                        var petRegistrations = JsonSerializer.Deserialize<List<PetRegistration>>(content, options);

                        // Return the first item if available
                        return petRegistrations?.FirstOrDefault();
                    }
                    catch (JsonException ex)
                    {
                        // Log or handle the deserialization error
                        Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                        return null;
                    }
                }
                return null;
            }
            throw new InvalidOperationException("Authentication data not found.");
        }


        private async Task<IEnumerable<T>> GetListAsync<T>(string endpoint)
        {
            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) ?? Enumerable.Empty<T>();
        }

        public Task<IEnumerable<Regions>> GetRegionsAsync() => GetListAsync<Regions>("/api/Location/regions");
        public Task<IEnumerable<Provinces>> GetProvincesByRegionCodeAsync(string regionCode) => GetListAsync<Provinces>($"/api/Location/provinces/{regionCode}");
        public Task<IEnumerable<Municipalities>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode) => GetListAsync<Municipalities>($"/api/Location/municipalities/{provinceCode}");
        public Task<IEnumerable<Barangays>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode) => GetListAsync<Barangays>($"/api/Location/barangays/{municipalityCode}");
        public Task<IEnumerable<SexType>> GetSexType() => GetListAsync<SexType>("/api/SexType/sex");
        public Task<IEnumerable<OwnerShipType>> GetOwnerShipTypes() => GetListAsync<OwnerShipType>("/api/PetRegistration/ownershipType");
        public Task<IEnumerable<AnimalColor>> GetAnimalColors() => GetListAsync<AnimalColor>("/api/PetRegistration/animalColor");
        public Task<IEnumerable<AnimalContact>> GetAnimalContactsAsync() => GetListAsync<AnimalContact>("/api/PetRegistration/animalContacts");
        public Task<IEnumerable<AnimalFemaleClassification>> GetAnimalFemaleClassificationsAsync() => GetListAsync<AnimalFemaleClassification>("/api/PetRegistration/animalFemaleClassificator");
        public Task<IEnumerable<PetTagType>> GetPetTagTypesAsync() => GetListAsync<PetTagType>("/api/PetRegistration/petTagType");
        public Task<IEnumerable<SpeciesBreed>> GetSpeciesBreedsAsync(string speciesCode) => GetListAsync<SpeciesBreed>($"/api/PetRegistration/speciesBreed/{speciesCode}");
        public Task<IEnumerable<SpeciesGroup>> GetSpeciesGroupsAsync() => GetListAsync<SpeciesGroup>("/api/PetRegistration/speciesGroup");
        public Task<IEnumerable<TagType>> GetTagTypesAsync() => GetListAsync<TagType>("/api/PetRegistration/tagType");

        public async Task<string> UploadImageAsync(Stream imageStream, string fileName)
        {
            using var httpContent = new MultipartFormDataContent();
            using var fileStreamContent = new StreamContent(imageStream);
            httpContent.Add(fileStreamContent, "file", fileName);

            var httpClient = httpClientFactory.CreateClient("custom-httpclient");
            var response = await httpClient.PostAsync("/api/UploadFile", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                throw new InvalidOperationException("Upload image failed.");
            }
        }
    }
}
