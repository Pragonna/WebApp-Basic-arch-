using Core.Security.Entities;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Core.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Core.Security.Extensions;

namespace Core.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            // Encryption // 
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string? token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

      // Creating json web token 
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
                                                       User user,
                                                       SigningCredentials signingCredentials,
                                                       IList<OperationClaim> operationClaims)
        {
            JwtSecurityToken jwt = new(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        // Setting Claims
        private IEnumerable<Claim> SetClaims(User user, IList<OperationClaim> operationClaims)
        {
            List<Claim> claims = new();
            claims.AddNameIdentifier(user.Id.ToString());                   // ID
            claims.AddEmail(user.Email);                                    // Email
            claims.AddName($"{user.FirstName} {user.LastName}");            // Full Name
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); // roles
            
            return claims;
        }

    }
}
