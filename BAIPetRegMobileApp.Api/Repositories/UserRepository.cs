using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Data.Entities;

namespace BAIPetRegMobileApp.Api.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(user => user.Username == username);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
