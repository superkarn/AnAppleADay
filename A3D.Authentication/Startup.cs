using A3D.Authentication.Data;
using A3D.Authentication.Models;
using A3D.Authentication.Services;
using A3D.Library.Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace A3D.Authentication
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
            // Set up some global configs
            Application.Api.BaseUrl = this.Configuration.GetSection("Applications")["Api:BaseUrl"];
            Application.Authentication.BaseUrl = this.Configuration.GetSection("Applications")["Authentication:BaseUrl"];
            Application.Web.BaseUrl = this.Configuration.GetSection("Applications")["Web:BaseUrl"];

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // https://docs.microsoft.com/en-us/aspnet/core/security/cookie-sharing?view=aspnetcore-2.2
            // Need the following to be able to share auth cookies between applications
            services.AddDataProtection()
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(this.Configuration.GetSection("Authentication")["DataProtection:FilePath"]))
                .SetApplicationName(AuthenticationConfigs.APPLICATION_NAME);

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = AuthenticationConfigs.COOKIE_NAME;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var jwtAppSettings = this.Configuration.GetSection("Jwt").Get<JwtAppSettings>();
            services.AddSingleton<JwtAppSettings>(jwtAppSettings);

            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtAppSettings.Issuer,
                        ValidAudience = jwtAppSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettings.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            // Needed so JWT can work
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin() // TODO replace this with WithOrigins()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build());
            });

            services.AddScoped<IJwtService, JwtService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            // https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2#enabling-cors-with-middleware
            // CORS Middleware must precede any defined endpoints in your app where you want to support cross-origin requests 
            // (for example, before the call to UseMvc for MVC/Razor Pages Middleware).
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
