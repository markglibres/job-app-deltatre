using System;
using DeltaTre.Domain.Seedwork;
using MediatR;
using Newtonsoft.Json;

namespace DeltaTre.Domain.Contacts.Events
{
    public class ContactCreatedEvent : IEvent, INotification
    {
        public Guid ContactId { get; private set; }
        public string Id { get; private set; }

        [JsonConstructor]
        private ContactCreatedEvent()
        {
            
        }
        public ContactCreatedEvent(Guid contactId)
        {
            ContactId = contactId;
            Id = Guid.NewGuid().ToString();
        }
    }
}
