using RSSCrudOperationsExample.Business.Dtos.Account;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Interfaces
{
    /// <summary>
    /// Needs to work with user identity
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Gets the user by email asynchronly
        /// </summary>
        /// <param name="email">Email property</param>
        /// <returns>Returns user model</returns>
        Task<User> GetByEmailAsync(string email);
        
        /// <summary>
        /// Gets the user by claim pricipal
        /// </summary>
        /// <param name="claimsPrincipal">Claim pricipal</param>
        /// <returns>Returns user model</returns>
        Task<User> GetAsync(ClaimsPrincipal claimsPrincipal);
                
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="dto">Register data transfer object</param>
        /// <returns>Returns new user model</returns>
        Task<User> CreateAsync(RegisterDto dto);
    }
}
