using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Application.Words;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Application.GetTopSearched
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
            var response = await _wordService.GetTopSearched(request.Top);

            return new GetTopSearchedQueryResponse
            {
                Results = response
            };
        }
    }
}