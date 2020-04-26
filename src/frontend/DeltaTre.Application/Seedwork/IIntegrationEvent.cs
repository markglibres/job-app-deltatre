using DeltaTre.Domain.Seedwork;

namespace DeltaTre.Application.Seedwork
{
    public interface IIntegrationEvent : IEvent
    {
        new string Id { get; set; }
    }
}