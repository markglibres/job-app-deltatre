using System;
using DeltaTre.Application.Search;
using DeltaTre.Application.Words;
using DeltaTre.Infrastructure.Grpc;
using DeltaTre.Search.Presentation.Rpc;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeltaTre.Presentation.Api
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var grpcConfigSection = configuration.GetSection("GrpcConfig");
            services.Configure<GrpcConfig>(grpcConfigSection);

            services.AddGrpcClient<WordService.WordServiceClient>(c =>
            {
                var config = grpcConfigSection.Get<GrpcConfig>();
                c.Address = new Uri(config.Server);
            });

            services.ConfigureHealthCheck();
            services.AddMediatR(typeof(SearchWordQuery).Assembly);
            services.AddTransient<IWordService, GrpcWordService>();

            return services;
        }

        public static IServiceCollection ConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }
    }
}