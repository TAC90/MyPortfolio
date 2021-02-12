using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolio.Data;
using MyPortfolio.Data.Entities;

namespace MyPortfolio.Web.Pages
{
    public class ExperiencesModel : PageModel
    {
        public List<Post> Posts { get; set; }

        public void OnGet()
        {
            var context = new PortfolioContext();
            //Get (numbered) list of blog posts with titles.
            //Create a viewmodel with required model data? Is this my viewmodel?
            using (context)
            {
                Posts = context.Posts.Where(p => p.CategoryId == 1).ToList();
            }
        }
    }
}
