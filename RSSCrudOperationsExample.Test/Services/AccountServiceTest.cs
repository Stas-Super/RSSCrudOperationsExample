using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RSSCrudOperationsExample.Business.Services;
using RSSCrudOperationsExample.Domain.Models;
using RSSCrudOperationsExample.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Test.Services
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public async Task GetByEmailAsync_ReturnsUserResponse()
        {
            var list = new List<User>
            {
                new User
                {
                    Email = "vasya_pupkin@gmail.com",
                    UserName = "vasya_pupkin"
                }
            };

            var mockedUserManager = MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(list.First()));

            var accountService = new AccountService(mockedUserManager.Object, null);
            var response = await accountService.GetByEmailAsync("vasya_pupkin@gmail.com");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Email);
            Assert.IsNotNull(response.UserName);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsUserResponse()
        {
            var user = new User
            {
                Id = 1,
                UserName = "vasya_pupkin",
                Email = "vasya_pupkin@gmail.com",
            };

            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com" },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com" },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com" },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com" },
            };

            var nameClaim = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());

            var claims = new List<Claim>();
            claims.Add(nameClaim);

            var claimIdentity = new ClaimsIdentity(claims);

            var claimPricial = new ClaimsPrincipal(claimIdentity);

            var mockedUserManager = MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(list.First(s => s.Id == 1));

            var service = new AccountService(mockedUserManager.Object, null);
            var response = await service.GetAsync(claimPricial);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.UserName);
        }
    }
}
