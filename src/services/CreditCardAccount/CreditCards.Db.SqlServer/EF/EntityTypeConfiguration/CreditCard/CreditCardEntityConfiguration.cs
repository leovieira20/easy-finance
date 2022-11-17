using CreditCards.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditCards.Db.SqlServer.EF.EntityTypeConfiguration.CreditCard;

public class CreditCardEntityConfiguration : IEntityTypeConfiguration<Domain.CreditCard>
{
    public void Configure(EntityTypeBuilder<Domain.CreditCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<CreditCardId.EfCoreValueConverter>();
    }
}