using DeltaTre.Application.Seedwork;

namespace DeltaTre.Application.CreateContact
{
    public class ContactAddedEvent : IIntegrationEvent
    {
        public string ContactId { get; set; }
        public string Id { get; set; }
    }
}