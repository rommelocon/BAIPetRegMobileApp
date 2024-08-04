using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.DTOs;
using BAIPetRegMobileApp.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var regions = await userDbContext.TblRegions
                .AsNoTracking()
                .Select(r => new RegionsDTO
                {
                    Rcode = r.Rcode,
                    RegionName = r.RegionName,
                })
                .ToListAsync();

            return regions;
        }

        public async Task<IEnumerable<ProvincesDTO>> GetProvincesByRegionCodeAsync(string regionCode)
        {
            var provinces = await userDbContext.TblProvinces
                .Where(p => p.Rcode == regionCode)
                .AsNoTracking()
                .Select(p => new ProvincesDTO
                {
                    ProvCode = p.ProvCode,
                    ProvinceName = p.ProvinceName
                })
                .ToListAsync();

            return provinces;
        }

        public async Task<IEnumerable<MunicipalitiesDTO>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode)
        {
            var municipalities = await userDbContext.TblMunicipalities
                .Where(p => p.ProvCode == provinceCode)
                .AsNoTracking()
                .Select(m => new MunicipalitiesDTO
                {
                    MunCode = m.MunCode,
                    MunCity = m.MunCity
                })
                .ToListAsync();

            return municipalities;
        }

        public async Task<IEnumerable<BarangaysDTO>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode)
        {
            var barangays = await userDbContext.TblBarangays
                .Where(p => p.MunCode == municipalityCode)
                .AsNoTracking()
                .Select(b => new BarangaysDTO
                {
                    Bcode = b.Bcode,
                    BarangayName = b.BarangayName
                })
                .ToListAsync();

            return barangays;
        }
    }
}
