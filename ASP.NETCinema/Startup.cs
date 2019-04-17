using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using ASPNETCinema.DAL;
using Microsoft.VisualStudio.Web.BrowserLink;
using DAL;

namespace ASPNETCinema
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => {
            options.LoginPath = "/User/LoginUser/";
            options.AccessDeniedPath = "/Home/AccessDenied/";
        });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //test
            services.AddScoped<IEmployeeContext, DatabaseEmployee>();
            services.AddScoped<IMovieContext, DatabaseMovie>();
            services.AddScoped<IHallContext, DatabaseHall>();
            services.AddScoped<IScreeningContext, DatabaseScreening>();
            services.AddScoped<IUserContext, DatabaseUser>();
            services.AddScoped<ITaskContext, DatabaseTask>();
            // Add the whole configuration object here.
            services.AddSingleton<IConfiguration>(Configuration);
            //services.AddTransient(_ => new DatabaseConnection(Configuration.GetConnectionString("ASPNETCinemaContextAZUREServer")));
            services.AddTransient(_ => new DatabaseConnection(Configuration.GetConnectionString("ASPNETCinemaContextFONTYSServer")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseBrowserLink();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Movie}/{action=ListMovies}/{id?}");
                
                
            });
        }
    }
}
