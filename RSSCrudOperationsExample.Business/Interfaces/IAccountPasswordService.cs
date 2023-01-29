using Microsoft.AspNetCore.Identity;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Interfaces
{
    /// <summary>
    /// Needs to work with user password
    /// </summary>
    public interface IAccountPasswordService
    {
        /// <summary>
        /// Password varification methed
        /// </summary>
        /// <param name="password">password from input</param>
        /// <param name="user">user that must to varify password</param>
        /// <returns>Returns password varification result</returns>
        PasswordVerificationResult VarifyPassword(string password, User user);
        
        /// <summary>
        /// Password hashed methed
        /// </summary>
        /// <param name="user">user thet will use this password</param>
        /// <param name="password">password of this user</param>
        /// <returns>Returns hashed password</returns>
        string HashPassword(User user, string password);
    }
}
