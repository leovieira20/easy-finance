using BankAccountModule.Domain.Events;

namespace BankAccountModule.Domain;

public abstract record AggregateBase<T> where T : AggregateBase<T>
{
    protected readonly List<AggregateEvent> Events = new List<AggregateEvent>();

    public List<AggregateEvent> GetUncommittedEvents()
    {
        return Events;
    }

    protected abstract T Apply(AggregateEvent @event); 

    protected T Emit(AggregateEvent @event)
    {
        Events.Add(@event);
        return Apply(@event);
    }
}