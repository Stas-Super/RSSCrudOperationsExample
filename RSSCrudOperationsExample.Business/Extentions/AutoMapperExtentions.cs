using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RSSCrudOperationsExample.Business.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Extentions
{
    public static class AutoMapperExtentions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new AccountMapProfile());
            }).CreateMapper();

            return services.AddSingleton(mapperConfig);
        }
    }
}
