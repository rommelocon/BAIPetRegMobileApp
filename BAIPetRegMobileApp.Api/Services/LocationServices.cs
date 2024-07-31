using BAIPetRegMobileApp.Api.Data;
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
            var regions = await userDbContext.TblRegions.AsNoTracking().ToListAsync();

            var regionsDto = regions.Select(b => new RegionsDTO
            {
                Rcode = b.Rcode,
                RegionName = b.RegionName,
            }).ToList();

            return regionsDto;
        }

        public async Task<IEnumerable<ProvincesDTO>> GetProvincesByRegionCodeAsync(string regionCode)
        {
            var provinces = await userDbContext.TblProvinces.Where(p=>p.Rcode == regionCode).AsNoTracking().ToListAsync();

            var provincesDto = provinces.Select(b => new ProvincesDTO
            {
                ProvCode = b.ProvCode,
                ProvinceName = b.ProvinceName
            }).ToList();

            return provincesDto;
        }

        public async Task<IEnumerable<MunicipalitiesDTO>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode)
        {
            var municipalities = await userDbContext.TblMunicipalities.Where(p => p.ProvCode == provinceCode).AsNoTracking().ToListAsync();

            var municipalitiesDto = municipalities.Select(b => new MunicipalitiesDTO
            {
                MunCode = b.MunCode,
                MunCity = b.MunCity
            }).ToList();

            return municipalitiesDto;
        }

        public async Task<IEnumerable<BarangaysDTO>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode)
        {
            return await userDbContext.TblBarangays
                .Where(b => b.MunCode == municipalityCode)
                .Select(b => new BarangaysDTO
                {
                    Bcode = b.Bcode,
                    BarangayName = b.BarangayName
                })
                .ToListAsync();
        }
    }
}
