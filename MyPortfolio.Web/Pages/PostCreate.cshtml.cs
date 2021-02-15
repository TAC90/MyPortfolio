using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolio.Data.Entities;
using MyPortfolio.Data;

namespace MyPortfolio.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PortfolioContext _context;
        [BindProperty]
        public Post Post { get; set; }
        public List<Category> Categories { get; set; }

        public CreateModel(PortfolioContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }
        public IActionResult OnPost()
        {
            //TODO: Integrate checking if title/entry already exists. If so, give alert.
            Post.Modified = Post.Created = DateTime.Now;
            Post.Public = false;
            _context.Add(Post);
            _context.SaveChanges();
            return RedirectToPage($"/PostEdit", new { Id = Post.Id });
        }
    }
}
