using System;
using EsatCelik.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EsatCelik.Blog.DataAccess.Concrete.EntityFramework
{
    public class BlogContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BlogContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connect to sql server database
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("UgurOkullariDiary"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
