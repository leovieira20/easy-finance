using System;
using BankAccountModule.Domain.Events;

namespace BankAccountModule.Domain.Tests.Unit.Entities;

public record PopulateSecondPropertyEvent(Guid AggregateId) : AggregateEvent(AggregateId)
{
    public Guid SecondProperty { get; init; } = Guid.NewGuid();
}