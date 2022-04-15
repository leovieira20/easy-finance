using CreditCardModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.SqlServer.EF.EntityTypeConfiguration.CreditCard;

public class CreditCardTransactionEntityConfiguration : IEntityTypeConfiguration<CreditCardTransaction>
{
    public void Configure(EntityTypeBuilder<CreditCardTransaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<CreditCardTransactionId.EfCoreValueConverter>();

        builder.Property(x => x.CreditCardId)
            .HasConversion<CreditCardId.EfCoreValueConverter>();
        
        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);
        
        builder.Property(x => x.CalculationAmount)
            .HasPrecision(18, 2);
    }
}