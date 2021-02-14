using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsatCelik.Blog.Api.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EsatCelik.Blog.Api.Helpers
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<AppIdentityDbContext>();
            var userStore = new UserStore<AppIdentityUser, AppIdentityRole, AppIdentityDbContext>(context);
            UserManager<AppIdentityUser> _userManager = scope.ServiceProvider.GetService<UserManager<AppIdentityUser>>();
            RoleManager<AppIdentityRole> _roleManager = scope.ServiceProvider.GetService<RoleManager<AppIdentityRole>>();


            string[] roles = new string[] { "Owner" };

            foreach (string role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    AppIdentityRole appIdentityRole = new AppIdentityRole()
                    {
                        Name = role
                    };

                    var roleResult = _roleManager.CreateAsync(appIdentityRole).Result;
                }
            }


            var user = new AppIdentityUser()
            {
                Email = "owner@example.com",
                NormalizedEmail = "OWNER@EXAMPLE.COM",
                UserName = "Owner",
                NormalizedUserName = "OWNER",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppIdentityUser>();
                var hashed = password.HashPassword(user, "blog123");
                user.PasswordHash = hashed;

                var result = userStore.CreateAsync(user);
            }

            foreach (var role in roles)
            {
                _userManager.AddToRoleAsync(user, role).Wait();
            }

            context.SaveChangesAsync();
        }
    }
}
