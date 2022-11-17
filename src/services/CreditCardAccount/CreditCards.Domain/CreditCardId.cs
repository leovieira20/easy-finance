using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    converters: StronglyTypedIdConverter.EfCoreValueConverter)]

namespace CreditCards.Domain;

[StronglyTypedId]
public partial struct CreditCardId {}