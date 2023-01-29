using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Interfaces
{
    /// <summary>
    /// Token service generates new tokens
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generates a new access token
        /// </summary>
        /// <param name="user">User thet will have new access token</param>
        /// <returns>New access token</returns>
        string GenerateAccessToken(User user);
        
        /// <summary>
        /// Generates a new refresh token
        /// </summary>
        /// <returns>Returns a new refresh token</returns>
        string GenerateRefreshToken();
    }
}
