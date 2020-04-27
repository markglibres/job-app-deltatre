using DeltaTre.Search.Domain.Seedwork;
using MediatR;

namespace DeltaTre.Search.Domain.Words.Events
{
    public class CreateWordRequestedEvent : IEvent, INotification
    {
        public string Value { get; set; }
        public string Id { get; set; }
    }
}