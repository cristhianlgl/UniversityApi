using ApiOpenUniversity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ApiOpenUniversity.ExtensionMethods
{
    public static class ExtensionSerives
    {
        public static IServiceCollection AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings jwtSettings = new JwtSettings();
            configuration.Bind("JsonWebTokenKeys", jwtSettings);

            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => 
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigninKey,
                    IssuerSigningKey =  new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSigninKey)),
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    RequireExpirationTime = jwtSettings.RequerieExpirationTime,
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                    ClockSkew=  TimeSpan.FromDays(1)
                };
            });

            return services;
        }

        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
