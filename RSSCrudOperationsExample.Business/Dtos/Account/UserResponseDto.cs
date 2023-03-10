using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Dtos.Account
{
    /// <summary>
    /// User response data transfer object
    /// </summary>
    public class UserResponseDto
    {
        /// <summary>
        /// User model
        /// </summary>
        public User User { get; set; }
        
        /// <summary>
        /// User access token property
        /// </summary>
        public string AccessToken { get; set; }
        
        /// <summary>
        /// User refresh token
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
