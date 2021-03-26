using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolio.Data;
using MyPortfolio.Data.Entities;

namespace MyPortfolio.Web.Pages
{
    public class PostsModel : PageModel
    {
        private readonly PortfolioContext _context;

        public List<Post> Posts { get; set; }

        public PostsModel(PortfolioContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Posts = _context.Posts.ToList();
        }
        public ActionResult OnPostDelete(int id)
        {
            var postToRemove = _context.Posts.Where(p => p.Id == id).SingleOrDefault();
            if (postToRemove != null)
            {
                _context.Posts.Remove(postToRemove);
                _context.SaveChanges();
            }
            return RedirectToPage("Posts");
        }
    }
}