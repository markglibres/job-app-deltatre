using System.Collections.Generic;
using DeltaTre.Search.Application.SearchWord;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words;
using DeltaTre.Search.Domain.Words.Events;
using DeltaTre.Search.Domain.Words.Seedwork;
using DeltaTre.Search.Infrastructure.EventBus;
using DeltaTre.Search.Infrastructure.Repositories;
using DeltaTre.Search.Presentation.Rpc.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Presentation.Rpc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddMediatR(typeof(SearchWordQuery).Assembly);
            services.AddSingleton<IRepository<Word>, InMemoryWordRepository>(opt =>
            {
                var logger = opt.GetService<ILogger<InMemoryWordRepository>>();
                var initialData = new List<Word>
                {
                    new Word("hello"),
                    new Word("goodbye"),
                    new Word("simple"),
                    new Word("list"),
                    new Word("search"),
                    new Word("filter"),
                    new Word("yes"),
                    new Word("no")
                };
                return new InMemoryWordRepository(logger, initialData);
            });
            services.AddTransient<IDomainEventsService, MediatrEventsService>();
            services.AddTransient<IWordService, WordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<SearchService>();

                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response.WriteAsync(
                            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                    });
            });
        }
    }
}