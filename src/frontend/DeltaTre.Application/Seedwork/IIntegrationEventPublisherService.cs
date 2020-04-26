using System.Threading;
using System.Threading.Tasks;

namespace DeltaTre.Application.Seedwork
{
    public interface IIntegrationEventPublisherService
    {
        Task Publish(IIntegrationEvent @event, CancellationToken cancellationToken);
    }
}