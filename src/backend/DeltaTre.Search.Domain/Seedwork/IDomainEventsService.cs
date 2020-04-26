using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeltaTre.Search.Domain.Seedwork
{
    public interface IDomainEventsService
    {
        Task Publish(IEvent @event, CancellationToken cancellationToken);
        Task Publish(IEnumerable<IEvent> domainEvents, CancellationToken cancellationToken);
    }
}