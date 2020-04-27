using System.Linq;
using System.Threading.Tasks;
using DeltaTre.Search.Application.CreateWords;
using DeltaTre.Search.Application.SearchWord;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Presentation.Rpc.Services
{
    public class WordService : Rpc.WordService.WordServiceBase
    {
        private readonly ILogger<WordService> _logger;
        private readonly IMediator _mediator;

        public WordService(
            ILogger<WordService> logger,
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

        public override async Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {
            _logger.LogInformation("updating word list...");

            var command = new CreateWordsCommand
            {
                Values = request.Word.ToList()
            };

            var response = await _mediator.Send(command);

            return new UpdateResponse
            {
                Success = response.Success
            };
        }
    }
}