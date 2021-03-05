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

        public ExperiencesModel(PortfolioContext context, IViewLocalizer viewLocalizer)
        {
            _context = context;
        }

        public void OnGet()
        {
            var cookieValue = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            var language = CookieRequestCultureProvider.ParseCookieValue(cookieValue);
            string languageCode = language.Cultures[0].Value;
            var languageId = _context.Languages.Where(l => l.Code2 == languageCode).FirstOrDefault().Id;
            
            //TODO: Culture/language selection implementation
            //Get (numbered) list of blog posts with titles.
            Posts = _context.Posts
                .Where(p => p.CategoryId == 1)
                .Include(p => p.Content.Where(c => c.LanguageId == languageId))
                .Where(p => p.Content.Count != 0 && p.Public == true)
                .ToList();
        }
    }
}
