using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.DTOs;

namespace BAIPetRegMobileApp.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly UserDbContext userDbContext;

        public LocationService(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public async Task<IEnumerable<RegionsDTO>> GetRegionsAsync()
        {
            return (IEnumerable<RegionsDTO>)await userDbContext.TblBarangays
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Provinces>> GetProvincesByRegionCodeAsync(string regionCode)
        {
            return await userDbContext.TblProvinces
                .Where(p => p.Rcode == regionCode)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Municipalities>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode)
        {
            return await userDbContext.TblMunicipalities
                .Where(m => m.ProvCode == provinceCode)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<BarangaysDTO>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode)
        {
            return await userDbContext.TblBarangays
                .Where(b => b.MunCode == municipalityCode)
                .Select(b => new BarangaysDTO
                {
                    BarangayName = b.BarangayName
                    // Map other properties as needed
                })
                .ToListAsync();
        }
    }
}
