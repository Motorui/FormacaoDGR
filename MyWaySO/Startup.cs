using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWaySO.Areas.Identity;
using MyWaySO.Areas.Identity.Models;
using MyWaySO.Areas.Identity.Services;
using MyWaySO.Data;
using Newtonsoft.Json.Serialization;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MyWaySO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-PT");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-PT") };
                options.RequestCultureProviders.Clear();
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                 ServiceLifetime.Transient);

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 4;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IAppRoleService, AppRoleService>();
            services.AddTransient<IAppUserRoleService, AppUserRoleService>();
            services.AddTransient<IUserUhService, UserUhService>();
            services.AddTransient<IUhService, UhService>();

            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjYwMTQ0QDMxMzgyZTMxMmUzMEFvdjd4dFY3QzJldHlOSDMwWHAzWVpBNDVCRUpNOEpYVitlVG5MT1BhMTA9");

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

            IList<CultureInfo> sc = new List<CultureInfo>
            {
                new CultureInfo("pt-PT")
            };

            var lo = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-PT"),
                SupportedCultures = sc,
                SupportedUICultures = sc
            };
            var cp = lo.RequestCultureProviders.OfType<CookieRequestCultureProvider>().First();
            cp.CookieName = "UserCulture"; // Or whatever name that you like

            app.UseRequestLocalization(lo);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
