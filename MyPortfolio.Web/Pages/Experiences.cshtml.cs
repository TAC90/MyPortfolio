using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
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

        public ActionResult OnGet(int id)
        {
            int languageId = GetLanguageId();
            if (id != 0)
            {
                Posts = _context.Posts
                    .Where(p => p.Id == id)
                    .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                    .ToList();
                return Page();
            }
            const int category = 2;
            const int indexCategory = 1;

            //TODO: Get (numbered) list of blog posts with titles.
            Posts = _context.Posts
                .Where(p => p.CategoryId == category)
                .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                .Where(p => p.Content.Count != 0 && p.Public == true)
                .ToList();
            //Get index post
            Posts.Insert(0,
                _context.Posts
                .Where(p => p.CategoryId == indexCategory && p.Title == "Experiences")
                .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                .FirstOrDefault());
            return Page();
        }

        private int GetLanguageId()
        {
            //TODO: Turn below into method approachable from anywhere, extension method?
            var cookieValue = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            var language = CookieRequestCultureProvider.ParseCookieValue(cookieValue);
            string languageCode = language.Cultures[0].Value;
            var languageId = _context.Languages.Where(l => l.Code2 == languageCode).FirstOrDefault().Id;
            return languageId;
        }
    }
}
