using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSCrudOperationsExample.Business.Interfaces;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.ApiServices.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user/feeds")]
    public class RssFeedController : ControllerBase
    {
        private readonly IRssFeedService _rssFeedService;
        private readonly IAccountService _accountService;

        public RssFeedController(
            IRssFeedService rssFeedService,
            IAccountService accountService)
        {
            _rssFeedService = rssFeedService;
            _accountService = accountService;
        }

        /// <summary>
        /// Creates a RSS feed
        /// </summary>
        /// <param name="url">RSS feed url</param>
        /// <returns>RSS feed</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromQuery] string url)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var feed = await _rssFeedService.CreateAsync(url,user);

            return Ok(feed);
        }

        /// <summary>
        /// Deletes RSS Feed from database
        /// </summary>
        /// <param name="id">RSS feed id</param>
        /// <returns>Returns string message</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            var user = await _accountService.GetAsync(HttpContext.User);
            var rssConnection = await _rssFeedService.GetAsync(id);

            await _rssFeedService.DeleteAsync(rssConnection.Id, user);

            return Ok("Rss feed was removed");
        }

        /// <summary>
        /// Get all RSS feeds of current user from database
        /// </summary>
        /// <param name="pageNumber">page number needs for pagination</param>
        /// <param name="pageSize">page size needs for pagination</param>
        /// <returns>Returns list of RSS feeds</returns>
        [HttpGet]
        public async Task<ActionResult<List<RssFeed>>> GetAllAsync(
            [FromQuery] int pageNumber, 
            [FromQuery] int pageSize)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var rssFeeds = await _rssFeedService.GetAllAsync(user.Id, pageNumber, pageSize);

            return Ok(rssFeeds);
        }

        /// <summary>
        /// Gets RSS feed by RSS feed id
        /// </summary>
        /// <param name="id">RSS feed id</param>
        /// <returns>Returns RSS feed</returns>
        [HttpGet("{id:int}")]
        public async Task<RssFeed> GetAsync([FromRoute] int id)
        {
            return await _rssFeedService.GetAsync(id);
        }

        /// <summary>
        /// Update RSS feed
        /// </summary>
        /// <param name="rssFeed">RSS Feed</param>
        /// <returns>Retruns RSS Feed</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] RssFeed rssFeed)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var updatedFeed = await _rssFeedService.UpdateAsync(rssFeed);

            return Ok(updatedFeed);
        }
    }
}
