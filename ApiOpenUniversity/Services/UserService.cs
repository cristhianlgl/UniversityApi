using ApiOpenUniversity.DataBase;
using ApiOpenUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiOpenUniversity.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> GetUsers() => _appDbContext.Users.AsNoTracking();

        public User? ValidateUser(UserLogin userLogin) => 
            _appDbContext?.Users?.Where(user =>
                user.Name.ToLower() == userLogin.UserName.ToLower() &&
                user.Password.Equals(userLogin.Password))
            .FirstOrDefault();
    }
}
