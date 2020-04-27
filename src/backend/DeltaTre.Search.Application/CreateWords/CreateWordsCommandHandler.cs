using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Words.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Application.CreateWords
{
    public class CreateWordsCommandHandler : IRequestHandler<CreateWordsCommand, CreateWordsCommandResponse>
    {
        private readonly ILogger<CreateWordsCommandHandler> _logger;
        private readonly IWordService _wordService;

        public CreateWordsCommandHandler(
            ILogger<CreateWordsCommandHandler> logger,
            IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        public async Task<CreateWordsCommandResponse> Handle(CreateWordsCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating words for {string.Join(", ", request.Values)}");
            await _wordService.Create(request.Values);

            return new CreateWordsCommandResponse
            {
                Success = true
            };
        }
    }
}