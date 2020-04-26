using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Application.Search;
using DeltaTre.Application.Words;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Application.SearchWord
{
    public class SearchWordQueryHandler : IRequestHandler<SearchWordQuery, SearchWordQueryResponse>
    {
        private readonly ILogger<SearchWordQueryHandler> _logger;
        private readonly IWordService _wordService;

        public SearchWordQueryHandler(
            ILogger<SearchWordQueryHandler> logger,
            IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        public async Task<SearchWordQueryResponse> Handle(SearchWordQuery request, CancellationToken cancellationToken)
        {
            var response = await _wordService.Search(request.Value);

            return new SearchWordQueryResponse
            {
                IsFound = response,
                Value = request.Value
            };
        }
    }
}