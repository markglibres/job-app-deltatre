using System;
using System.Threading;
using System.Threading.Tasks;
using DeltaTre.Application.CreateContact;
using DeltaTre.Application.Seedwork;
using DeltaTre.Domain.Contacts.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Application.Events
{
    public class ContactCreatedEventHandler : INotificationHandler<ContactCreatedEvent>
    {
        private readonly ILogger<ContactCreatedEventHandler> _logger;
        private readonly IIntegrationEventPublisherService _integrationEventPublisherService;

        public ContactCreatedEventHandler(
            ILogger<ContactCreatedEventHandler> logger,
            IIntegrationEventPublisherService integrationEventPublisherService)
        {
            _logger = logger;
            _integrationEventPublisherService = integrationEventPublisherService;
        }

        public async Task Handle(ContactCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ContactCreatedEventHandler)} has been handled by mediatr");
            _logger.LogInformation("Do your stuff here");

            var contactAddedEvents = new ContactAddedEvent
            {
                ContactId = notification.Id,
                Id = Guid.NewGuid().ToString()
            };

            await _integrationEventPublisherService.Publish(contactAddedEvents, cancellationToken);
        }
    }
}