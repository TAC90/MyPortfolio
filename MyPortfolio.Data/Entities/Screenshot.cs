using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Data.Entities
{
    public class Screenshot
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}