using A3D.Library.Global;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;

namespace A3D.Web
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

            services.AddDataProtection()
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(this.Configuration.GetSection("Authentication")["DataProtection:FilePath"]))
                .SetApplicationName(AuthenticationConfigs.APPLICATION_NAME);

            services.AddAuthentication(AuthenticationConfigs.AUTHENTICATION_SCHEME)
                .AddCookie(AuthenticationConfigs.AUTHENTICATION_SCHEME, options =>
                {
                    options.Cookie.Name = AuthenticationConfigs.COOKIE_NAME;
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = (context) =>
                        {
                            var returnUrl = WebUtility.UrlEncode($"/Redirect?url={context.Request.Path}&application=Web");

                            context.HttpContext.Response.Redirect(
                                Application.Authentication.BaseUrl
                                + $"/Identity/Account/Login?ReturnUrl={returnUrl}");
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
