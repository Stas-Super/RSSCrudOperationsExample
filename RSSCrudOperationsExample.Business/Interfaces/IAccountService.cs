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
    public interface IAccountService
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetAsync(ClaimsPrincipal claimsPrincipal);
        Task<User> CreateAsync(RegisterDto dto);
    }
}
