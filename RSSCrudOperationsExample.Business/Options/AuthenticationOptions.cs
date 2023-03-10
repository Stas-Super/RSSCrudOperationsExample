using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Options
{
    /// <summary>
    /// Authentication options
    /// </summary>
    public class AuthenticationOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresAfterMitutes { get; set; }
        public string SigningKey { get; set; }
        public byte[] SigningKeyBytes => Convert.FromBase64String(SigningKey);

    }
}
