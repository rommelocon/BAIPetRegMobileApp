using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.DTOs;

namespace BAIPetRegMobileApp.Api.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<RegionsDTO>> GetRegionsAsync();
        Task<IEnumerable<Provinces>> GetProvincesByRegionCodeAsync(string regionCode);
        Task<IEnumerable<Municipalities>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode);
        Task<IEnumerable<BarangaysDTO>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode);
    }
}
