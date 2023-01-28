using Microsoft.Extensions.DependencyInjection;
using RSSCrudOperationsExample.Domain.Interfaces;
using RSSCrudOperationsExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Domain.Extentions
{
    public static class RepositoriesDepndencyInjectionExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IRssFeedRepository, RssFeedRepository>();
        }
    }
}
