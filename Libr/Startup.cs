using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Libr.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Libr.Data.Interfaces;
using Libr.Data.Repository;
using Libr.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Identity.UI.Services;
using Libr.Areas.Identity.Pages.Account;

namespace Libr
{
    public class Startup
    {
        public string connection;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddDbContext<BooksContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<CartContext>(options =>
             options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<OrdersContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //    services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            //неправильно написанный код в userManager!



            services.AddScoped<BookRepository>();
            services.AddScoped<CartRepository>();
            services.AddScoped<OrdersRepository>();
            services.AddScoped<UserManager<IdentityUser>>();


            //services.AddTransient<UserManager<IdentityUser>>();
            //services.AddTransient<ApplicationDbContext>();

            //services.AddTransient<IEmailSender, RegisterModel>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
