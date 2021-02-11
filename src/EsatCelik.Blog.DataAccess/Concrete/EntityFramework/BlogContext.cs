using System;
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

        public DbSet<Tag> Tags { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }

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
            
        }
    }
}
