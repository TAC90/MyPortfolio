using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public List<Content> Content { get; set; }
        public List<PostScreenshot> Screenshots { get; set; }
        public bool Public { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
