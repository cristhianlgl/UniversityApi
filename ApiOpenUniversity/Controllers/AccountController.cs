using ApiOpenUniversity.Helpers;
using ApiOpenUniversity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOpenUniversity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private JwtSettings _jwtSettings;
        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<User> Logins =  new List<User>()
        {
            new User()
            { 
                Id = 1,
                FirtsName = "admin",
                Password = "12345" ,
                Email = "admin@correo.com"
            },
            new User()
            { 
                Id = 2,
                FirtsName = "user1",
                Password = "12345",
                Email = "admin@correo.com"
            }
        };

        [HttpPost]
        public IActionResult GetLogin(UserLogin userLogin) 
        {
            try
            {
                var user = Logins.FirstOrDefault(x => x.FirtsName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if (user is null)
                {
                    return BadRequest("Invalid username or password");
                }

                var token = JwtHelper.GetTokenKey(new UserTokens()
                { 
                    UserName = user.FirtsName,
                    EmailId = user.Email,
                    Id = user.Id
                }, _jwtSettings );
                 
                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Get Token Error", ex);
            }
        }

        [HttpGet]
        [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
                    Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }
}
