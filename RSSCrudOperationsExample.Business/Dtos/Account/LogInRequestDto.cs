using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Dtos.Account
{
    /// <summary>
    /// Login data transfer object
    /// </summary>
    public class LogInRequestDto
    {
        /// <summary>
        /// Email property
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Password property
        /// </summary>
        public string Password { get; set; }
    }
}
