using System.Threading.Tasks;
using DeltaTre.Search.Application.SearchWord;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Presentation.Rpc.Services
{
    public class SearchService : Searcher.SearcherBase
    {
        private readonly ILogger<SearchService> _logger;
        private readonly IMediator _mediator;

        public SearchService(
            ILogger<SearchService> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task<SearchResponse> Find(SearchRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"searching for {request.Word}...");

            var query = new SearchWordQuery
            {
                Word = request.Word
            };

            var response = await _mediator.Send(query);

            return new SearchResponse
            {
                Found = response.IsFound,
                Word = response.Word
            };
        }
    }
}