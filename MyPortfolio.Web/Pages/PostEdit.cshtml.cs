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
    public class PostEditModel : PageModel
    {
        private readonly PortfolioContext _context;
        [BindProperty]
        public Post Post { get; set; }
        [BindProperty]
        public List<Content> Contents { get; set; }
        public List<Category> Categories { get; set; }
        public List<Language> Languages { get; set; }
        public PostEditModel(PortfolioContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            //TODO: Implement check if id exists
            //if(!_context.Posts.Any(p => p.Id == id))
            //{
            //    //What to do when none found?
            //}
            Categories = _context.Categories.ToList();
            Languages = _context.Languages.ToList();
            Post = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            Contents = Post.Content ?? new List<Content>();
            //Check if content list has all languages
            if (Contents.Count != Languages.Count)
            {
                //Populate Content with amount of language options, skip existing
                for (int i = 0; i < Languages.Count; i++)
                {
                    //Check if content has language id
                    if (!Contents.Any(c => c.LanguageId == Languages[i].Id))
                    {
                        //Add new content object to list if none found
                        Contents.Add(new Content
                        {
                            LanguageId = Languages[i].Id,
                            PostId = Post.Id
                        });
                    }
                }
            }
        }
        public void OnPost()
        {

        }
    }
}
