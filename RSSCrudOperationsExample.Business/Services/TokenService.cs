using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RSSCrudOperationsExample.Business.Interfaces;
using RSSCrudOperationsExample.Business.Options;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AuthenticationOptions> _options;

        public TokenService(IOptions<AuthenticationOptions> options)
        {
            _options = options;
        }

        public string GenerateAccessToken(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                _options.Value.Issuer,
                _options.Value.Audience,
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                },
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(_options.Value.ExpiresAfterMitutes),
                new SigningCredentials(
                        new SymmetricSecurityKey(_options.Value.SigningKeyBytes),
                        SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public string GenerateRefreshToken()
        {
            var code = new byte[1024];
            using (var randomNamberGenerator = RandomNumberGenerator.Create())
            {
                randomNamberGenerator.GetBytes(code);
                return Convert.ToBase64String(code);
            }
        }
    }
}
