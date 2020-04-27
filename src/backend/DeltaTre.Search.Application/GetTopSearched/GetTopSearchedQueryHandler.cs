using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Words.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Application.GetTopSearched
{
    public class GetTopSearchedQueryHandler : IRequestHandler<GetTopSearchedQuery, GetTopSearchedQueryResponse>
    {
        private readonly ILogger<GetTopSearchedQueryHandler> _logger;
        private readonly IWordService _wordService;

        public GetTopSearchedQueryHandler(
            ILogger<GetTopSearchedQueryHandler> logger,
            IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        public async Task<GetTopSearchedQueryResponse> Handle(GetTopSearchedQuery request,
            CancellationToken cancellationToken)
        {
            var results = await _wordService.GetTopSearched(request.Limit);

            return new GetTopSearchedQueryResponse
            {
                Results = results.ToList().Select(r => new TopSearchInfo
                {
                    Word = r.Value,
                    Count = r.Count
                })
            };
        }
    }
}