using System;
using BankAccountModule.Domain.Events;
using FluentAssertions;
using Xunit;

namespace BankAccountModule.Domain.Tests.Unit.Entities;

public class AggregateBaseTests
{
    private TestAggregate _aggregate;

    public AggregateBaseTests()
    {
        _aggregate = new TestAggregate();
    }

    [Fact]
    public void CannotEmitNullEvent()
    {
        var action = () => _aggregate.PerformAction(null);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void WhenActionHappensThenEventIsStored()
    {
        _aggregate.PerformAction(new TestEvent());

        _aggregate.GetUncommittedEvents().Should().HaveCount(1);
    }

    [Fact]
    public void WhenActionHappensThenStateIsUpdated()
    {
        var @event = new TestEvent();
        
        _aggregate = _aggregate.PerformAction(@event);
        
        _aggregate.Id.Should().Be(@event.AggregateId);
    }
}

public record TestEvent() : AggregateEvent(Guid.NewGuid());