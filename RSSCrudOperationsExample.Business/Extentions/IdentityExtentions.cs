using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RSSCrudOperationsExample.Domain.EF;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Extentions
{
    public static class IdentityExtentions
    {
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApiDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
