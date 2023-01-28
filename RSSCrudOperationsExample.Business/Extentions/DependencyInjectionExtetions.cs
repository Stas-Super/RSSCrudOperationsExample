using Microsoft.Extensions.DependencyInjection;
using RSSCrudOperationsExample.Business.Interfaces;
using RSSCrudOperationsExample.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Extentions
{
    public static class DependencyInjectionExtetions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<ITokenService, TokenService>()
                .AddScoped<IAccountPasswordService, AccountPasswordService>()
                .AddScoped<IAccountService, AccountService>();
        }
    }
}
