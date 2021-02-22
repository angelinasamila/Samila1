using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samila1.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
