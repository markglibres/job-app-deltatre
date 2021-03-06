﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DeltaTre.Search.Domain.Seedwork
{
    public abstract class Entity : IEntity, IHasEvents
    {
        public Guid Id { get; private set; }
        public IList<IEvent> Events { get; }
        public void ClearEvents()
        {
            Events.Clear();
        }

        protected Entity()
        {
            Events = new List<IEvent>();
            Id = Guid.NewGuid();
        }

        protected void Emit(IEvent @event)
        {
            if (Events.Any(e => e.Id == @event.Id)) return;

            Events.Add(@event);
        }


        
    }
}
