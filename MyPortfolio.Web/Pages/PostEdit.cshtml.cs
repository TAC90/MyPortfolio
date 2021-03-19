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
        public IActionResult OnGet(int id)
        {
            if (!_context.Posts.Any(p => p.Id == id))
            {
                return RedirectToPage("Index");
            }
            PopulateOptions();
            Post = _context.Posts.Where(p => p.Id == id).Include(p => p.Content).ThenInclude(c => c.Language).FirstOrDefault();
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
                            Language = Languages[i],
                            LanguageId = Languages[i].Id,
                            PostId = Post.Id
                        });
                    }
                }
                _context.Update(Post);
                _context.SaveChanges();
            }
            Post.Content = Contents;
            Console.WriteLine(string.Empty);
            return Page();
        }

        private void PopulateOptions()
        {
            Categories = _context.Categories.Select(c =>
            new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            Languages = _context.Languages.ToList();
        }

        public void OnPost()
        {
            Post.Modified = DateTime.Now;
            //TODO: Check if content text was modified, update if so. Use StateChanged event?
            //TODO: See if there's a better way to handle images and how they are saved, right now it's done automatically by QuillJS by saving it as a base64 string
            _context.Update(Post);
            _context.SaveChanges();
            Console.WriteLine(string.Empty);
            PopulateOptions();
        }
    }
}

//TODO: Add ability to remove entries