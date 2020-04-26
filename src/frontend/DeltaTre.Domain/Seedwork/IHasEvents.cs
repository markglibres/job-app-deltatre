using System.Collections.Generic;

namespace DeltaTre.Domain.Seedwork
{
    public interface IHasEvents
    {
        IList<IEvent> Events { get; }
    }
}