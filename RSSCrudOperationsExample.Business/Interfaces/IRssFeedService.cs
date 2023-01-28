using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Interfaces
{
    public interface IRssFeedService
    {
        Task<RssFeed> CreateAsync(string url, User user);
        Task DeleteAsync(int id, User user);
        Task<RssFeed> GetAsync(int id);
        Task<IEnumerable<RssFeed>> GetAllAsync(int userId, int pageNumber, int pageSize);
        Task<RssFeed> UpdateAsync(RssFeed rssFeed);
    }
}
