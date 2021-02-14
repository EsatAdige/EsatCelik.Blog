using System;
using System.Collections.Generic;
using EsatCelik.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class BlogContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public BlogContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connect to sql server database
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("EsatCelikBlog"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Articles' Categories
            modelBuilder.Entity<ArticleCategory>()       // THIS IS FIRST
                .HasOne(u => u.Article).WithMany(u => u.ArticleCategories).IsRequired().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ArticleCategory>().HasKey(sc => new { sc.ArticleId, sc.CategoryId });

            modelBuilder.Entity<ArticleCategory>()
                .HasOne<Article>(sc => sc.Article)
                .WithMany(s => s.ArticleCategories)
                .HasForeignKey(sc => sc.ArticleId);


            modelBuilder.Entity<ArticleCategory>()
                .HasOne<Category>(sc => sc.Category)
                .WithMany(s => s.ArticleCategories)
                .HasForeignKey(sc => sc.CategoryId);
            #endregion

            modelBuilder.Entity<Category>().HasData(GetAllCategories());
        }

        private List<Category> GetAllCategories()
        {
            return new List<Category>()
            {
                new Category() {Id = 1, CategoryName = "Game", InsertDate = DateTime.Now},
                new Category() {Id = 2, CategoryName = "Travel", InsertDate = DateTime.Now},
                new Category() {Id = 3, CategoryName = "Photography", InsertDate = DateTime.Now}
            };
        }
    }
}
