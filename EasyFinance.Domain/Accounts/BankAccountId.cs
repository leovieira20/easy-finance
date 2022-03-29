using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    converters: StronglyTypedIdConverter.EfCoreValueConverter)]

namespace EasyFinance.Domain.Accounts;

[StronglyTypedId]
public partial struct BankAccountId { }