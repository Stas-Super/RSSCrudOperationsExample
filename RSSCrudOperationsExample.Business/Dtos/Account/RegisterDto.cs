using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Dtos.Account
{
    /// <summary>
    /// Register data transfer object needs to register new user
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// User email address property
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// User name property
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password of user property
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Confirm password must equal password
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
