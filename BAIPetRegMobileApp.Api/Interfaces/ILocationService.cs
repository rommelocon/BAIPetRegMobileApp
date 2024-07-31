using BAIPetRegMobileApp.Api.DTOs;

namespace BAIPetRegMobileApp.Api.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<RegionsDTO>> GetRegionsAsync();
        Task<IEnumerable<ProvincesDTO>> GetProvincesByRegionCodeAsync(string regionCode);
        Task<IEnumerable<MunicipalitiesDTO>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode);
        Task<IEnumerable<BarangaysDTO>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode);
    }
}
