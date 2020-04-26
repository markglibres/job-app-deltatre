using System.Threading.Tasks;
using DeltaTre.Application.Words;
using DeltaTre.Search.Presentation.Rpc;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Infrastructure.Grpc
{
    public class GrpcWordService : IWordService
    {
        private readonly ILogger<GrpcWordService> _logger;
        private readonly Searcher.SearcherClient _searcherClient;

        public GrpcWordService(
            ILogger<GrpcWordService> logger,
            Searcher.SearcherClient searcherClient)
        {
            _logger = logger;
            _searcherClient = searcherClient;
        }

        public async Task<bool> Search(string value)
        {
            _logger.LogInformation($"searching {value} with grpc");
            var reply = await _searcherClient.FindAsync(new SearchRequest
            {
                Word = value
            });

            return reply.Found;
        }
    }
}