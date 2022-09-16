using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public interface IUserService
    {
        User? ValidateUser(UserLogin userLogin);
        IEnumerable<User> GetUsers();

    }
}
