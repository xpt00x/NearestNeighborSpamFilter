using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using System;
using System.Configuration;
using AutoMapper;
using NearestNeighborsSpamFilter.App.Infrastructure.Repositories;

namespace NearestNeighborsSpamFilter.App.Infrastructure
{
    public static class ServiceCollectionExtensions
    {

        public static void AddNearestNeighborSpamFilter(this IServiceCollection services, string connectionString) { 
        
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContext<NnDbContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MappingProfileORM));

        }
    }
}
