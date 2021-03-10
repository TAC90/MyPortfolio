using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Data.Entities;

namespace MyPortfolio.Web.Pages
{
    public class AboutMeModel : PageModel
    {
        private readonly PortfolioContext _context;

        public List<Post> Posts { get; set; }

        public AboutMeModel(PortfolioContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //TODO: Turn below into method approachable from anywhere, extension method?
            var cookieValue = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            var language = CookieRequestCultureProvider.ParseCookieValue(cookieValue);
            string languageCode = language.Cultures[0].Value;

            var languageId = _context.Languages.Where(l => l.Code2 == languageCode).FirstOrDefault().Id;
            Posts = _context.Posts
                .Where(p => p.CategoryId == 1 && p.Title == "AboutMe")
                .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                .ToList();
        }
    }
}
