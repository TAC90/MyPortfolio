using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Data.Entities;

namespace MyPortfolio.Web.Pages
{
    public class PostEditModel : PageModel
    {
        private readonly PortfolioContext _context;
        [BindProperty]
        public Post Post { get; set; }
        public List<SelectListItem> Categories { get; set; }
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
            //    //Do I need `using` during these database inquiries and otherwise, or does DI handle this automatically?
            //}
            Categories = _context.Categories.Select(c =>
            new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            Languages = _context.Languages.ToList();
            Post = _context.Posts.Where(p => p.Id == id).Include(p => p.Content).FirstOrDefault();
            var Contents = Post.Content ?? new List<Content>();
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
            Console.WriteLine(string.Empty);
        }
        public void OnPost()
        {
            _context.Update(Post);
            //Update both changes individually, or will updating post also add the content?
            //_context.Update(Contents);
            //_context.SaveChanges();
            Console.WriteLine(string.Empty);
        }
    }
}
