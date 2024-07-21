using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
