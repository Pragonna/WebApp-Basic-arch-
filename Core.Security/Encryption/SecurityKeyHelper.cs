using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption
{
    public class SecurityKeyHelper
    {
        // Created Security Key via Microsoft.IdentityModel.Tokens
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); // Encoding to byte for SymmetricSecurityKey`s parameter
        }

    }
}
