using Data;
using Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Support;
using Orchestrator.Common;
using Orchestrator.Common.Contract;
using Repository.Common;
using Repository.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.EntityFrameworkCore;


namespace Api
{
    public static class ServiceExtensions
    {

        public static AppConfig ConfigureAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfigSection = configuration.GetSection("AppConfig");
            var appConfig = appConfigSection.Get<AppConfig>();
            services.Configure<AppConfig>(appConfigSection);

            return appConfig;
        }

        public static void ConfigureCors(this IServiceCollection services, CorsConfig corsConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsConfig.CorsPolicy, builder =>
               {
                   builder.WithOrigins(corsConfig.AllowedCorsDomains)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();


               });

            });
        }



        public static void ConfigureRepository(this IServiceCollection services)
        {
            #region add Context and UnitOfWork 
            services.AddTransient<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork<ApplicationDbContext>, UnitOfWork<ApplicationDbContext>>();
            #endregion

            #region Common
            services.AddScoped<IAppResourceRepository, AppResourceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            #endregion
        }

        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:EduraConnection"];

           services.AddDbContext<ApplicationDbContext>(opts => 
           opts.UseSqlServer(connectionString));
  
        }

        public static void ConfigureOrchestrators(this IServiceCollection services)
        {
            #region Common
            services.AddScoped<IAppResourceOrchestrator, AppResourceOrchestrator>();
            services.AddScoped<ICityOrchestrator, CityOrchestrator>();
            #endregion
        }

    } 

}

