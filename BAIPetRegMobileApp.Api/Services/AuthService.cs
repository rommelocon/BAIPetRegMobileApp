using BAIPetRegMobileApp.Api.Helpers;
using BAIPetRegMobileApp.Api.Repositories;
using BAIPetRegMobileApp.Data.Entities;

namespace BAIPetRegMobileApp.Api.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null) return false;

            return PasswordHelper.VerifyPassword(password, user.Password);
        }

        public void Register(User user)
        {
            user.Password = PasswordHelper.HashPassword(user.Password);
            _userRepository.AddUser(user);
        }
    }
}
