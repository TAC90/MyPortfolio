using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Many to Many setup
            builder.Entity<PostScreenshot>().HasKey(ps => new { ps.PostId, ps.ScreenshotId });

            //Necessary?
            builder.Entity<Content>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Content)
                .HasForeignKey(c => c.PostId);


            //Seed Data
            builder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "English", Code = "ENG" },
                new Language { Id = 2, Name = "Dutch", Code = "NLD" }
                );
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Experience" },
                new Category { Id = 2, Name = "Concepts" },
                new Category { Id = 3, Name = "Designed" }
                );
        }
    }
}
