using CreditCardModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Db.SqlServer.EF.EntityTypeConfiguration.CreditCard;

public class CreditCardEntityConfiguration : IEntityTypeConfiguration<CreditCardModule.Domain.CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCardModule.Domain.CreditCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<CreditCardId.EfCoreValueConverter>();
    }
}