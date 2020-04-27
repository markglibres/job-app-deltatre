using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Application.Words;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Application.UpdateWords
{
    public class UpdateWordsCommandHandler : IRequestHandler<UpdateWordsCommand, UpdateWordsCommandResponse>
    {
        private readonly ILogger<UpdateWordsCommandHandler> _logger;
        private readonly IWordService _wordService;

        public UpdateWordsCommandHandler(
            ILogger<UpdateWordsCommandHandler> logger,
            IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        public async Task<UpdateWordsCommandResponse> Handle(UpdateWordsCommand request,
            CancellationToken cancellationToken)
        {
            var response = await _wordService.Update(request.Values);
            return new UpdateWordsCommandResponse
            {
                Success = response
            };
        }
    }
}