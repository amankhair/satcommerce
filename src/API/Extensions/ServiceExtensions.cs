﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options => 
            { 
                options.AddPolicy("CorsPolicy", builder => 
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()); 
            });

        public static void ConfigureSqlContext(this IServiceCollection services, 
            IConfiguration configuration) => 
                services.AddDbContext<StoreContext>(opts => 
                    opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
