using Microsoft.AspNetCore.Identity;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Interfaces
{
    public interface IAccountPasswordService
    {
        PasswordVerificationResult VarifyPassword(string password, User user);
        string HashPassword(User user, string password);
    }
}
