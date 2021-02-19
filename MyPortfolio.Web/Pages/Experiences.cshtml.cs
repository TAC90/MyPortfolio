using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            int languageId = 1; //TODO: Culture/language selection implementation
            //Get (numbered) list of blog posts with titles.
            Posts = _context.Posts
                .Where(p => p.CategoryId == 1)
                .Include(p => p.Content)
                .Where(p => p.Content.Count != 0 && p.Public == true)
                .Where(p => p.Content.Any(c => c.LanguageId == languageId))
                .ToList();
        }
    }
}
