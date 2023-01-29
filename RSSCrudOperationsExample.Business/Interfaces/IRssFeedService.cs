using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Interfaces
{
    /// <summary>
    /// RSS feed service that will work with RSS connections 
    /// </summary>
    public interface IRssFeedService
    {
        /// <summary>
        /// Creates a new RSS feed
        /// </summary>
        /// <param name="url">RSS feed url</param>
        /// <param name="user">User thet want to save this rss connection</param>
        /// <returns></returns>
        Task<RssFeed> CreateAsync(string url, User user);
        
        /// <summary>
        /// Removes the RSS feed
        /// </summary>
        /// <param name="id">RSS feed id</param>
        /// <param name="user">User thet has this RSS feed</param>
        /// <returns></returns>
        Task DeleteAsync(int id, User user);
        
        /// <summary>
        /// Gets RSS feed by id
        /// </summary>
        /// <param name="id">RSS feed id</param>
        /// <returns>Returns RSS feed</returns>
        Task<RssFeed> GetAsync(int id);
        
        /// <summary>
        /// Gets all RSS feeds of user
        /// </summary>
        /// <param name="userId">current user id</param>
        /// <param name="pageNumber">Page number for pagintation</param>
        /// <param name="pageSize">Page size for pagination</param>
        /// <returns>Returns list of RSS feeds</returns>
        Task<IEnumerable<RssFeed>> GetAllAsync(int userId, int pageNumber, int pageSize);
        
        /// <summary>
        /// Update RSS feed
        /// </summary>
        /// <param name="rssFeed">RSS feed</param>
        /// <returns>Updated RSS feed</returns>
        Task<RssFeed> UpdateAsync(RssFeed rssFeed);
    }
}
