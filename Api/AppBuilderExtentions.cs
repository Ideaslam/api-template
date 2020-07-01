using Microsoft.AspNetCore.Builder;
using Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class AppBuilderExtentions
    {
        public static void ConfigureCors(this IApplicationBuilder app, CorsConfig corsConfig)
        {
            app.UseCors(corsConfig.CorsPolicy);
            app.UseCors(builder => builder.WithOrigins(corsConfig.AllowedCorsDomains)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        }
    }
}
