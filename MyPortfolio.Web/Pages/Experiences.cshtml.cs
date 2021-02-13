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
        private readonly PortfolioContext _context;

        public List<Post> Posts { get; set; }

        public ExperiencesModel(PortfolioContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //Get (numbered) list of blog posts with titles.
            //Create a viewmodel with required model data? Is this my viewmodel?
            using (_context)
            {
                Posts = _context.Posts.Where(p => p.CategoryId == 1).ToList();
            }
        }
    }
}
