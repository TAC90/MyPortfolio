using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Data.Entities;

namespace MyPortfolio.Web.Pages.P
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioContext _context;

        public List<Post> Posts { get; set; }
        public Category Category { get; set; }

        public IndexModel(PortfolioContext context)
        {
            _context = context;
        }
        public ActionResult OnGet(string category)
        {
            if (!_context.Categories.Any(c => c.Name == category))
            {
                return NotFound();
            }
            Category = _context.Categories.Single(c => c.Name == category);
            int categoryId = Category.Id;
            int languageId = _context.GetLanguageId();
            const int indexCategory = 1;

            //TODO: Get (numbered) list of blog posts with titles.
            Posts = _context.Posts
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                .Where(p => p.Content.Count != 0 && p.Public == true)
                .ToList();

            //Get index post, don't get if on next page?
            Posts.Insert(0,
                _context.Posts
                .Where(p => p.CategoryId == indexCategory && p.Title == Category.Name)
                .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                .FirstOrDefault());
            if (Posts[0] == null) return NotFound();
            return Page();
        }
    }
}
