﻿using ApiTheMusicalKind.Backend.Services;
using ApiTheMusicalKind.Backend.Services.Lyric;
using ApiTheMusicalKind.Backend.Services.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTheMusicalKind.Backend
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //AddQueries(services);
            AddServices(services);

            return services;
        }

        private static void AddQueries(IServiceCollection services)
        {
            //services.AddTransient<IBaseQuery, BaseQuery>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IDeezerService, DeezerService>();
            services.AddSingleton<ILyricService, LyricService>();

        }
    }
}
