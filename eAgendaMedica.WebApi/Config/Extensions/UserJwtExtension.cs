using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.WebApi.ViewModels.AuthModule;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class UserJwtExtension
    {
        public static TokenViewModel GenerateJwt(this User user, DateTime expirationDate)
        {
            string keyToken = CreateKeyToken(user, expirationDate);

            var token = new TokenViewModel
            {
                Key = keyToken,
                ExpirationDate = expirationDate,
                User = new UserTokenViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Login = user.UserName
                }
            };

            return token;
        }

        private static string CreateKeyToken(User user, DateTime expirationDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes("SegredoSuperSecretoDoeAgenda");

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "eAgendaMedica",
                Audience = "http://localhost",
                Subject = GetIdentityClaims(user),
                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            });

            string keyToken = tokenHandler.WriteToken(token);

            return keyToken;
        }

        private static ClaimsIdentity GetIdentityClaims(User user)
        {
            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.GivenName, user.Name));

            return identityClaims;
        }
    }
}
