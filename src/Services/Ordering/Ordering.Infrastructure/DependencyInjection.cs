﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            //// Add Services to the container
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(connectionString));
            //services.AddScoped<IApplicationDbContext, AppDbContext>();

            return services;
        }
    }
}
