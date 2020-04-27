using System;
using DeltaTre.Application.CreateContact;
using DeltaTre.Application.Seedwork;
using DeltaTre.Application.Words;
using DeltaTre.Domain.Contacts;
using DeltaTre.Domain.Contacts.Seedwork;
using DeltaTre.Domain.Seedwork;
using DeltaTre.Infrastructure.EventBus;
using DeltaTre.Infrastructure.Grpc;
using DeltaTre.Infrastructure.Repositories;
using DeltaTre.Search.Presentation.Rpc;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeltaTre.Presentation.Api
{
    public static class ConfigureHealthCheckExtension
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
            services.AddMediatR(typeof(CreateContactCommandHandler).Assembly);

            services.AddTransient<IDomainEventsService, MediatrEventsService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IContactRepository, InMemoryContactRepository>();
            services.AddTransient<IIntegrationEventPublisherService, AzureServiceBusPublisherService>();
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