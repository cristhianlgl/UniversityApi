using ApiOpenUniversity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiOpenUniversity.Helpers
{
    public static class JwtHelper
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccount, Guid id)
        { 
            List<Claim> claims = new List<Claim>() 
            {
                new Claim("Id", userAccount.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.EmailId),
                new Claim(ClaimTypes.NameIdentifier, id.ToString() ),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow
                            .AddDays(1).ToString("MM ddd dd yyyy HH:mm:ss tt") )

            };

            if (userAccount.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }
            else if (userAccount.UserName == "User1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccount,out Guid id)
        {
            id = Guid.NewGuid();
            return GetClaims(userAccount, id);
        }

        public static UserTokens GetTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if (model is null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                //Obtain Secret Key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigninKey);

                Guid guidId;

                // Expires in day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // validity of our token
                userToken.Validity = expireTime.TimeOfDay;

                //GENERATE OUR JWT
                var jwtToken = new JwtSecurityToken
                    (
                        issuer: jwtSettings.ValidAudience,
                        audience: jwtSettings.ValidAudience,
                        claims: GetClaims(model, out guidId),
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256)
                    );

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = guidId;
                return userToken;

            }
            catch (Exception ex)
            {
                throw new Exception("Error Generating the JWT", ex);    
            }
        }
    }
}
