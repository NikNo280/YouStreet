using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouStreet.Data.Interfaces;
using YouStreet.Data.Models;
using YouStreet.Data.Repositories;
using YouStreet.Hubs;
using YouStreet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using YouStreet.Data.Logger;
using YouStreet.Data.EmailSevice;

namespace YouStreet
{
    public class Startup
    {
        private IConfigurationRoot ConfSetting;

        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment hostEnv)
        {
            ConfSetting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserDb, UserRepository>();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(ConfSetting.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
            services.AddTransient<ISender, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/ErrorPro");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Error/Index", "?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseSignalR(route =>
            {
                route.MapHub<ChatHub>("/Chat");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "GlobalLogger.txt"), 
                Path.Combine(Directory.GetCurrentDirectory(), "ErrorLogger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
        }
    }
}
