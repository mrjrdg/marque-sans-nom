using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Managers;
using Services;
using Microsoft.AspNetCore.Identity;
using Models;

namespace webapp
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<UserManagerSQL>();
            services.AddScoped<IBusinessServices, BusinessManagerSQL>();
            services.AddScoped<IEventServices, EventManagerSQL>();
            services.AddScoped<IEventTypeServices, EventTypeManagerSQL>();
            services.AddScoped<IAddressServices, AddressManagerSQL>();
            services.AddScoped<IMessageConversationServices, MessageConversationManagerSQL>();
            services.AddScoped<IMessageServices, MessageManagerSQL>();

            services.AddDbContextPool<AppDbContext>(options =>
            {
                    options.UseSqlServer(Configuration.GetConnectionString("JordanGauthierDatabaseContext"));
                    options.EnableSensitiveDataLogging(true);
            });

            // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //                 .AddEntityFrameworkStores<AppDbContext>();
            // services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            // {
            //     options.Password.RequireDigit = false;
            //     options.Password.RequireLowercase = false;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireUppercase = false;
            // })
            // .AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/Index";
                options.SlidingExpiration = true;
            });
            // /Account/AccessDenied
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            app.UseEndpoints(endpoints =>
       {
           endpoints.MapRazorPages();
       });
        }
    }
}
