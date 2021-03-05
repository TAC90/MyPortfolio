using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPortfolio.Data.Entities
{
    public class Language
    {
        public int Id { get; set; }
        [StringLength(3)]
        public string Code { get; set; }
        public string Code2 { get; set; }
        [Display(Name = "Language")]
        public string Name { get; set; }
    }
}
