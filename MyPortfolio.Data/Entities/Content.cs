using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Data.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
