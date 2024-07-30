using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.Interfaces;

namespace BAIPetRegMobileApp.Api.Services
{
    public class SexTypeService : BaseService<SexType>, ISexTypeService
    {
        public SexTypeService(UserDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SexType>> GetSexTypeAsync()
        {
            return await GetAllAsync();
        }
    }
}
