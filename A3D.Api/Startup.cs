﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using A3D.Library.Models.LookUp;
using A3D.Library.Repositories.EntityFramework;
using A3D.Library.Repositories.EntityFramework.LookUp;
using A3D.Library.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using A3D.Library.Services;
using A3D.Library.Services.LookUp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace A3D.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            var connectionString = Microsoft
                .Extensions
                .Configuration
                .ConfigurationExtensions
                .GetConnectionString(this.Configuration, "DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityInstanceService, ActivityInstanceService>();
            services.AddScoped<IActivityNotificationService, ActivityNotificationService>();

            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityInstanceRepository, ActivityInstanceRepository>();
            services.AddScoped<IActivityNotificationRepository, ActivityNotificationRepository>();

            services.AddScoped<ILookUpRepository<ActivityPrivacy>, ActivityPrivacyRepository>();
            services.AddScoped<ILookUpRepository<ActivityStatus>, ActivityStatusRepository>();
            services.AddScoped<ILookUpRepository<NotificationType>, NotificationTypeRepository>();
            services.AddScoped<ILookUpService, LookUpService>();
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

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
