using System;
using System.Collections.Generic;
using System.Linq;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.BusinessLogics;
using PetClinicDatabaseImplement.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PetClinicRestApi
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<ReportClientLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IVisitLogic, VisitLogic>();
            services.AddTransient<IServiceLogic, ServiceLogic>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();
            services.AddTransient<BackUpAbstractLogic, BackupLogic>();
            services.AddTransient<MainLogic>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
