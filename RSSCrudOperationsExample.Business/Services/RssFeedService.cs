using AutoMapper;
using RSSCrudOperationsExample.Business.Interfaces;
using RSSCrudOperationsExample.Domain.Interfaces;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Services
{
    public class RssFeedService : IRssFeedService
    {
        private readonly IRssFeedRepository _rssFeedRepository;
        private readonly IMapper _mapper;

        public RssFeedService(
            IRssFeedRepository rssFeedRepository,
            IMapper mapper)
        {
            _rssFeedRepository = rssFeedRepository;
            _mapper = mapper;
        }

        public async Task<RssFeed> CreateAsync(string url, User user)
        {
            var rssFeed = _mapper.Map<RssFeed>(url);
            rssFeed.User = user;
            rssFeed.UserId = user.Id;

            user.RssFeeds.Add(rssFeed);

            await _rssFeedRepository.CreateAsync(rssFeed);

            return rssFeed;
        }

        public async Task DeleteAsync(int id, User user)
        {
            var rssFeed = await _rssFeedRepository.GetAsync(id);
            
            user.RssFeeds.Remove(rssFeed);

            await _rssFeedRepository.DeleteAsync(rssFeed);
        }

        public async Task<IEnumerable<RssFeed>> GetAllAsync(int userId, int pageNumber, int pageSize)
        {
            return await _rssFeedRepository.GetAllAsync(userId, pageNumber, pageSize);
        }

        public Task<RssFeed> GetAsync(int id)
        {
            return _rssFeedRepository.GetAsync(id);
        }

        public async Task<RssFeed> UpdateAsync(RssFeed rssFeed)
        {
            return await _rssFeedRepository.UpdateAsync(rssFeed);
        }
    }
}
