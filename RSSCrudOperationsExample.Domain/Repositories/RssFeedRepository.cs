using Microsoft.EntityFrameworkCore;
using RSSCrudOperationsExample.Domain.EF;
using RSSCrudOperationsExample.Domain.Interfaces;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Domain.Repositories
{
    public class RssFeedRepository : IRssFeedRepository
    {
        private readonly ApiDbContext _context;

        public RssFeedRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(RssFeed rssFeed)
        {
            await _context.AddAsync(rssFeed);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RssFeed rssFeed)
        {
            _context.Remove(rssFeed);

            await _context.SaveChangesAsync();
        }

        public async Task<List<RssFeed>> GetAllAsync(int userId, int pageNumber, int pageSize)
        {
            return await _context.RssFeeds
                .Where(rssFeed => rssFeed.UserId == userId)
                .OrderByDescending(rssFeed => rssFeed.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<RssFeed> GetAsync(int id)
        {
            return await _context.RssFeeds
                .Where(rssFeed => rssFeed.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<RssFeed> UpdateAsync(RssFeed rssFeed)
        {
            _context.RssFeeds.Update(rssFeed);

            await _context.SaveChangesAsync();

            return rssFeed;
        }
    }
}
