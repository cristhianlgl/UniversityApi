using ApiOpenUniversity.DataBase;
using ApiOpenUniversity.Helpers;
using ApiOpenUniversity.Models;
using ApiOpenUniversity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiOpenUniversity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userService;
        public AccountController(IUserService userService,  JwtSettings jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
        }

        [HttpPost]
        public IActionResult GetLogin(UserLogin userLogin) 
        {
            try
            {
                var user = _userService.ValidateUser(userLogin);
                if (user is null)
                {
                    return BadRequest("Invalid username or password");
                }

                var token = JwtHelper.GetTokenKey(new UserTokens()
                { 
                    UserName = user.Name,
                    EmailId = user.Email,
                    Id = user.Id,
                    Role = user.Role,
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
            return Ok(_userService.GetUsers());
        }

    }
}
