using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsatCelik.Blog.Api.Helpers;
using EsatCelik.Blog.Api.Identity;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.Business.Concrete;
using EsatCelik.Blog.DataAccess.Abstract;
using EsatCelik.Blog.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace EsatCelik.Blog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddAutoMapper(typeof(Startup));

            #region DI for Services and Managers
            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IArticleCategoryService, ArticleCategoryManager>();
            services.AddScoped<IArticleCategoryDal, EfArticleCategoryDal>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IResourceService, ResourceManager>();
            services.AddScoped<IResourceDal, EfResourceDal>();

            services.AddScoped<IUserInformationService, UserInformationManager>();
            services.AddScoped<IUserInformationDal, EfUserInformationDal>();
            #endregion

            services.AddDbContext<BlogContext>();
            services.AddDbContext<AppIdentityDbContext>();

            #region Microsoft Identity Configuration
            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(15);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                options.LogoutPath = "/Users/Logout";
                options.AccessDeniedPath = "/Users/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EsatCelik.Blog.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EsatCelik.Blog.Api v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            SampleData.Initialize(app.ApplicationServices);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
