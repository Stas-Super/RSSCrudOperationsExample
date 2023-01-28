using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Domain.Interfaces
{
    public interface IRssFeedRepository
    {
        Task CreateAsync(RssFeed rssFeed);
        Task DeleteAsync(RssFeed rssFeed);
        Task<List<RssFeed>> GetAllAsync(int userId, int pageNumber, int pageSize);
        Task<RssFeed> GetAsync(int id);
        Task<RssFeed> UpdateAsync(RssFeed rssFeed);
    }
}
