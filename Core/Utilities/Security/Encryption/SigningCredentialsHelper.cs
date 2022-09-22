using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //webapi'nin kullanabileceği jwt oluşturulması için 
        //mesela kullanıcı adı parola credentilas'dır
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //hangi anahtarı ve algoritmayı kullanacaksın demek
            return new SigningCredentials( securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
