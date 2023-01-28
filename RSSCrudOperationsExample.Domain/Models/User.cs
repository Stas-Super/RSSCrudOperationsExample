using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string RefreshToken { get; set; }

        [Column(TypeName = "date")]
        public DateTime RefreshTokenExpirce { get; set; }

        public List<RssFeed> RssFeeds { get; set; }
    }
}
