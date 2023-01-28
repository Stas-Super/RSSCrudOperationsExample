using Microsoft.AspNetCore.Identity;
using RSSCrudOperationsExample.Business.Interfaces;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Services
{
    public class AccountPasswordService : IAccountPasswordService
    {
        private readonly UserManager<User> _userManager;

        public AccountPasswordService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string HashPassword(User user, string password)
        {
            return _userManager.PasswordHasher.HashPassword(user, password);
        }

        public PasswordVerificationResult VarifyPassword(string password, User user)
        {
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if(result != PasswordVerificationResult.Success)
            {
                throw new Exception("Password not valid");
            }

            return result;
        }
    }
}
