using System.Collections.Generic;

namespace DeltaTre.Search.Domain.Seedwork
{
    public interface IHasEvents
    {
        IList<IEvent> Events { get; }
    }
}