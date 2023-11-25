using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class JwtConfigExtension
    {
        public static void ConfigureJwt(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("SegredoSuperSecretoDoeAgenda");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidAudience = "http://localhost",
                    ValidIssuer = "eAgendaMedica"
                };
            });
        }
    }
}
