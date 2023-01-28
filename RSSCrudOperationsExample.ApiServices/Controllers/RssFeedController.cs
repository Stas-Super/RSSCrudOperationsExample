using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSSCrudOperationsExample.Business.Interfaces;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromQuery] string url)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var feed = await _rssFeedService.CreateAsync(url,user);

            return Ok(feed);
        }
    }
}
