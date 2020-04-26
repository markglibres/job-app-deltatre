using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Words.Events;
using DeltaTre.Search.Domain.Words.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Application.Events
{
    public class WordSearchedEventHandler : INotificationHandler<WordSearchedEvent>
    {
        private readonly ILogger<WordSearchedEventHandler> _logger;
        private readonly IWordService _wordService;

        public WordSearchedEventHandler(
            ILogger<WordSearchedEventHandler> logger,
            IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        public async Task Handle(WordSearchedEvent notification, CancellationToken cancellationToken)
        {
            await _wordService.IncrementCount(notification.WordId);
        }
    }
}