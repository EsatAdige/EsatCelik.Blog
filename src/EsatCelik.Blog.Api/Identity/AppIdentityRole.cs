using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EsatCelik.Blog.Api.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public AppIdentityRole()
        {
            
        }

        public AppIdentityRole(string roleName) : base(roleName)
        {
        }
    }
}
