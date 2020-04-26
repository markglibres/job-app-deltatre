using System;
using DeltaTre.Search.Domain.Seedwork;
using MediatR;

namespace DeltaTre.Search.Domain.Words.Events
{
    public class WordSearchedEvent : IEvent, INotification
    {
        public string Id { get; set; }
        public Guid WordId { get; set; }
    }
}