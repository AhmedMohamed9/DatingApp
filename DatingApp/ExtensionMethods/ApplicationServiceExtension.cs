using DatingApp.DataContext;
using DatingApp.Interfaces;
using DatingApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.ExtensionMethods
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection addapplicationservices(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.AddScoped<ITokenService, TokenServices>();
            services.AddDbContextPool<context>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatingApp", Version = "v1" });
            });
           
            return services;
        }
    }
}
