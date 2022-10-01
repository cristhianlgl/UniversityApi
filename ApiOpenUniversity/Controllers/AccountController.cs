using ApiOpenUniversity.Helpers;
using ApiOpenUniversity.Models;
using ApiOpenUniversity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ApiOpenUniversity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userService;
        private readonly IStringLocalizer<AccountController> _strLocalizer;
        public AccountController(IUserService userService,  JwtSettings jwtSettings, IStringLocalizer<AccountController> stringLocalizer)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
            _strLocalizer = stringLocalizer;
        }

        [HttpPost]
        public IActionResult GetLogin(UserLogin userLogin) 
        {
            try
            {
                var user = _userService.ValidateUser(userLogin);
                if (user is null)
                {
                    return BadRequest(_strLocalizer.GetString("messageBadRequest").Value);
                }

                var token = JwtHelper.GetTokenKey(new UserTokens()
                { 
                    UserName = user.Name,
                    EmailId = user.Email,
                    Id = user.Id,
                    Role = user.Role,
                    MessageWelcome = _strLocalizer.GetString("welcome").Value
                }, _jwtSettings );
                 
                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception(_strLocalizer.GetString("messageError").Value, ex);
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
