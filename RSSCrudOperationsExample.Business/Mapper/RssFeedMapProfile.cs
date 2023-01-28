using AutoMapper;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Mapper
{
    public class RssFeedMapProfile : Profile
    {
        public RssFeedMapProfile()
        {
            CreateMap<string, RssFeed>()
                .ForMember(rssFeed => rssFeed.Name, options => options.MapFrom(name => Guid.NewGuid().ToString()))
                .ForMember(rssFeed => rssFeed.UserId, options => options.Ignore())
                .ForMember(rssFeed => rssFeed.User, options => options.Ignore())
                .ForMember(rssFeed => rssFeed.IsActive, options => options.MapFrom(options => true))
                .ForMember(rssFeed => rssFeed.Description, options => options.Ignore())
                .ForMember(rssFeed => rssFeed.Id, options => options.Ignore());
        }
    }
}
