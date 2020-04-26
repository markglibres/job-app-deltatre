using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Words.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Application.SearchWord
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
            var isFound = await _wordService.Search(request.Word);

            return new SearchWordQueryResponse
            {
                IsFound = isFound,
                Word = request.Word
            };
        }
    }
}