using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EsatCelik.Blog.Api.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        protected readonly IConfiguration Configuration;

        public AppIdentityDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("EsatCelikBlog"));
        }
    }
}
