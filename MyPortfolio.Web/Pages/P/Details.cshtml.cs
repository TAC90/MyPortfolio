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
    public class DetailsModel : PageModel
    {
        private readonly PortfolioContext _context;

        public Post Post { get; set; }
        public Category Category { get; set; }
        public DetailsModel(PortfolioContext context)
        {
            _context = context;
        }

        public ActionResult OnGet(string category, int id)
        {
            if (!_context.Posts.Any(p => p.Id == id) && !_context.Categories.Any(c => c.Name == category))
            {
                return NotFound();
            }
            Category = _context.Categories.Single(c => c.Name == category);
            //Both checking for any and placing category in object, is there a better way? Put category in object, then check for null? Do 2 context queries even slow things down?
            int languageId = _context.GetLanguageId();
            Post = _context.Posts
                    .Where(p => p.Id == id)
                    .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                    .FirstOrDefault();
            //TODO: Create check if post actually has content to display
            if (Post.Content.Count == 0) return NotFound();
            return Page();
        }

        
    }
}
