using System;
using System.Globalization;
using System.Reflection;
using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlvTeam.Application.Users.Commands.AddLocation;
using SlvTeam.Domain.Entities;
using SlvTeam.WebUI.Helpers;
using WebApplication1.Data;
using WebApplication1.Helpers;
using WebApplication1.HostedServices;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var culture = new CultureInfo("ru-RU");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", false, true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                          .AddEnvironmentVariables();
        
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                                                            options.UseNpgsql(connectionString));
            services.AddIdentity<SlvTeamUser, IdentityRole>(options =>
                    {
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequiredUniqueChars = 0;
                    })
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddHangfire(config => { config.UseMemoryStorage(); });

            services.AddMediatR(typeof(AddLocationCommand).GetTypeInfo().Assembly);

            services.AddControllersWithViews();

            services.AddHostedService<MigrationHostedService>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var options = new BackgroundJobServerOptions { WorkerCount = Environment.ProcessorCount * 2 };
            app.UseHangfireServer(options);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                                                 "Admin",
                                                 "Admin",
                                                 "Admin/{Controller=Home}/{Action=Index}/{id?}");

                endpoints.MapControllerRoute(
                                             "default",
                                             "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            CreateRole();
        }

        public void CreateRole()
        {
            BackgroundJob.Enqueue<CreateRolesTask>(x => x.Execute());
            BackgroundJob.Enqueue<PhotoDecoder>(x => x.Execute());
        }
    }
}