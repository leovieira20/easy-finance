using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    converters: StronglyTypedIdConverter.EfCoreValueConverter)]

namespace BankAccounts.Domain.Aggregates.BankAccountAggregate;

[StronglyTypedId]
public partial struct BankAccountId { }