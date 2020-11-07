using System.Collections.Generic;

namespace Cube.Domain.Aggregates
{
    public abstract class AggregateRoot : Entity
    {
        // In Case we want to Add some Events. 
        private List<DomainEvent> _events = new List<DomainEvent>();
    }
}
