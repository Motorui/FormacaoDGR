using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using FormacaoDGR.Areas.Identity;
using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Areas.Identity.Services;
using FormacaoDGR.Data;
using FormacaoDGR.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Sotsera.Blazor.Toaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FormacaoDGR
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
            services.AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = true; // optional
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

            services.AddToaster(config =>
            {
                //example customizations
                config.PositionClass = Defaults.Classes.Position.TopCenter;
                config.PreventDuplicates = true;
                config.NewestOnTop = false;
            });

            services.AddHttpContextAccessor();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            #region Localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // define the list of cultures your app will support
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("pt")
                };
                // set the default culture
                options.DefaultRequestCulture = new RequestCulture("pt");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>() {
                 new QueryStringRequestCultureProvider() // Here, You can also use other localization provider
                };
            });
            #endregion

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

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();

            #region Serviçes
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IAppRoleService, AppRoleService>();
            services.AddTransient<IAppUserRoleService, AppUserRoleService>();
            services.AddTransient<IUserUhService, UserUhService>();
            services.AddTransient<IUhService, UhService>();

            services.AddTransient<ICodigoPostalService, CodigoPostalService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<ICursosFormandoService, CursosFormandoService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IFormandoService, FormandoService>();
            services.AddTransient<IFormandoDetalheService, FormandoDetalheService>();
            services.AddTransient<IGrupoService, GrupoService>();
            services.AddTransient<IMarcacaoInicialService, MarcacaoInicialService>();
            services.AddTransient<IRefrescamentoService, RefrescamentoService>();
            services.AddTransient<IRefrescamentosFormandoService, RefrescamentosFormandoService>();
            services.AddTransient<ISalaService, SalaService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Localization
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            #endregion

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

            app.ApplicationServices
              .UseBootstrapProviders()
              .UseFontAwesomeIcons();

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
