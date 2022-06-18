using System;
using Ardalis.GuardClauses;
using BankAccountModule.Domain.Events;

namespace BankAccountModule.Domain.Tests.Unit.Entities;

public record TestAggregate : AggregateBase<TestAggregate>
{
    public TestAggregate PerformAction(AggregateEvent @event)
    {
        Guard.Against.Null(@event);
        return Emit(@event);
    }

    protected override TestAggregate Apply(AggregateEvent @event)
    {
        return @event switch
        {
            TestEvent => this with { Id = @event.AggregateId },
            PopulateSecondPropertyEvent propertyEvent => this with { SecondProperty = propertyEvent.SecondProperty },
            _ => this
        };
    }

    public Guid Id { get; set; }
    public Guid SecondProperty { get; set; }
}