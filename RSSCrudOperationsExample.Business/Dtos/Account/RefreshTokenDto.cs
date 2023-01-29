using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Dtos.Account
{
    /// <summary>
    /// Refresh token data transfer object
    /// </summary>
    public class RefreshTokenDto
    {
        /// <summary>
        /// Access token property
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token property
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
