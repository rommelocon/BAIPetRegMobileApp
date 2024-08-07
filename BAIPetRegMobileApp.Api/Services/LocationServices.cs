using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.DTOs;
using BAIPetRegMobileApp.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAIPetRegMobileApp.Api.Services
{
    public class LocationService : ILocationService
    {
        private readonly UserDbContext _userDbContext;

        public LocationService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<IEnumerable<RegionsDTO>> GetRegionsAsync()
        {
            // Consider adding indexing on Rcode and RegionName columns if not already indexed
            return await _userDbContext.TblRegions
                .AsNoTracking()
                .Select(r => new RegionsDTO
                {
                    Rcode = r.Rcode,
                    RegionName = r.RegionName
                })
                .OrderByDescending(p => p.RegionName)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProvincesDTO>> GetProvincesByRegionCodeAsync(string regionCode)
        {
            // Ensure that Rcode is indexed in TblProvinces table
            return await _userDbContext.TblProvinces
                .AsNoTracking()
                .Where(p => p.Rcode == regionCode)
                .Select(p => new ProvincesDTO
                {
                    ProvCode = p.ProvCode,
                    ProvinceName = p.ProvinceName
                })
                .OrderByDescending(p => p.ProvinceName)
                .ToListAsync();
        }

        public async Task<IEnumerable<MunicipalitiesDTO>> GetMunicipalitiesByProvinceCodeAsync(string provinceCode)
        {
            // Ensure that ProvCode is indexed in TblMunicipalities table
            return await _userDbContext.TblMunicipalities
                .AsNoTracking()
                .Where(m => m.ProvCode == provinceCode)
                .Select(m => new MunicipalitiesDTO
                {
                    MunCode = m.MunCode,
                    MunCity = m.MunCity
                })
                .OrderByDescending(p => p.MunCity)
                .ToListAsync();
        }

        public async Task<IEnumerable<BarangaysDTO>> GetBarangaysByMunicipalityCodeAsync(string municipalityCode)
        {
            // Ensure that MunCode is indexed in TblBarangays table
            return await _userDbContext.TblBarangays
                .AsNoTracking()
                .Where(b => b.MunCode == municipalityCode)
                .Select(b => new BarangaysDTO
                {
                    Bcode = b.Bcode,
                    BarangayName = b.BarangayName
                })
                .OrderByDescending(p => p.BarangayName)
                .ToListAsync();
        }
    }
}
