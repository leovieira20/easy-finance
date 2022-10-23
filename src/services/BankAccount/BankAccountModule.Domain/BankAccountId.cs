using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    converters: StronglyTypedIdConverter.EfCoreValueConverter)]

namespace BankAccountModule.Domain;

[StronglyTypedId]
public partial struct BankAccountId { }