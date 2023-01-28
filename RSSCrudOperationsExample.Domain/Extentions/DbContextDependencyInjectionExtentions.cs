using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RSSCrudOperationsExample.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Domain.Extentions
{
    public static class DbContextDependencyInjectionExtentions
    {
        public static IServiceCollection AddApiDbContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
