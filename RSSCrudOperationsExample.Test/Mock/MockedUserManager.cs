﻿using Microsoft.AspNetCore.Identity;
using Moq;
using RSSCrudOperationsExample.Business.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSSCrudOperationsExample.Test.Mock
{
    public class MockedUserManager
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var authOptions = new Mock<AuthenticationOptions>();

            var mockedUserManager = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mockedUserManager.Object.UserValidators.Add(new UserValidator<TUser>());
            mockedUserManager.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            mockedUserManager.Object.PasswordHasher = new PasswordHasher<TUser>();

            mockedUserManager.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mockedUserManager.Setup(x => x.CreateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success).Callback<TUser>((x) => ls.Add(x));
            mockedUserManager.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mockedUserManager;
        }
    }
}
