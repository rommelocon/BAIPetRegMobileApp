using BAIPetRegMobileApp.Api.Data.User;

namespace BAIPetRegMobileApp.Api.Interfaces
{
    public interface ISexTypeService
    {
        Task<IEnumerable<SexType>> GetSexTypeAsync();
    }
}
