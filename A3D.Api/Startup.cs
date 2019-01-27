using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A3D.Library.Repositories.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore.Mvc;
using A3D.Library.Services.Interfaces;
using A3D.Library.Services;
using A3D.Library.Repositories.LookUp;
using A3D.Library.Models.LookUp;

namespace A3D.Api
{
    public class Startup
    {
        // SimpleInjector initializer code
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Microsoft
                .Extensions
                .Configuration
                .ConfigurationExtensions
                .GetConnectionString(this.Configuration, "DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // SimpleInjector initializer code
            IntegrateSimpleInjector(services);
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
                app.UseHsts();
            }

            #region SimpleInjector initializer code
            InitializeContainer(app);

            // Add custom middleware
            //app.UseMiddleware<CustomMiddleware1>(container);
            //app.UseMiddleware<CustomMiddleware2>(container);

            container.Verify();
            #endregion

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        #region SimpleInjector initializer code
        // https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html#wiring-custom-middleware
        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services. For instance:
            container.Register<IActivityService, ActivityService>(Lifestyle.Scoped);
            container.Register<IActivityInstanceService, ActivityInstanceService>(Lifestyle.Scoped);
            container.Register<IActivityNotificationService, ActivityNotificationService>(Lifestyle.Scoped);
            container.Register<ILookUpRepository<ActivityPrivacy>, ActivityPrivacyRepository>(Lifestyle.Scoped);
            container.Register<ILookUpRepository<ActivityStatus>, ActivityStatusRepository>(Lifestyle.Scoped);
            container.Register<ILookUpRepository<NotificationType>, NotificationTypeRepository>(Lifestyle.Scoped);
            container.Register<ILookUpService, LookUpService>(Lifestyle.Scoped);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);
        }
        #endregion
    }
}
