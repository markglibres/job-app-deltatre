using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Words.Events;
using DeltaTre.Search.Domain.Words.Seedwork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Application.Events
{
    public class CreateWordRequestedEventHandler : INotificationHandler<CreateWordRequestedEvent>
    {
        private readonly ILogger<CreateWordRequestedEventHandler> _logger;
        private readonly IWordService _wordService;

        public CreateWordRequestedEventHandler(
            ILogger<CreateWordRequestedEventHandler> logger,
            IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        public async Task Handle(CreateWordRequestedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"creating word {notification.Value}");
            var response = await _wordService.Create(notification.Value);
        }
    }
}