using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // Created SigningCredentials used SecurityKey
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(
                securityKey, 
                SecurityAlgorithms.HmacSha512Signature); // Algorithm - HmacSha512
        }
    }
}
