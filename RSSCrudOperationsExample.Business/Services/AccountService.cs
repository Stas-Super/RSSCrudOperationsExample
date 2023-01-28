using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RSSCrudOperationsExample.Business.Dtos.Account;
using RSSCrudOperationsExample.Business.Interfaces;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;

namespace RSSCrudOperationsExample.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(RegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);

            await _userManager.CreateAsync(user);

            return user;
        }

        public async Task<User> GetAsync(ClaimsPrincipal claimsPrincipal)
        {
           return await _userManager.GetUserAsync(claimsPrincipal);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
