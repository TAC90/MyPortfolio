using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Data.Entities
{
    public class PostScreenshot
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int ScreenshotId { get; set; }
        public Screenshot Screenshot { get; set; }
        public int Order { get; set; }
    }
}
