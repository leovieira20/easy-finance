using StronglyTypedIds;

[assembly: StronglyTypedIdDefaults(
    converters: StronglyTypedIdConverter.EfCoreValueConverter)]

namespace CreditCardModule.Domain;

[StronglyTypedId]
public partial struct CreditCardId {}