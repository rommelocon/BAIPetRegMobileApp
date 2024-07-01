using BAIPetRegMobileApp.Models;

namespace BAIPetRegMobileApp.Services;
public interface ILoginRepository
{
    Task<User> Login(string email, string password);
}
