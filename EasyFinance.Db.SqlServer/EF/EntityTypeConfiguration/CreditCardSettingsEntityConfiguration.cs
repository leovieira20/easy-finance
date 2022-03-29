using EasyFinance.Domain;
using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Db.SqlServer.EF.EntityTypeConfiguration;

public class CreditCardSettingsEntityConfiguration : IEntityTypeConfiguration<CreditCardSettings>
{
    public void Configure(EntityTypeBuilder<CreditCardSettings> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<CreditCardSettingsId.EfCoreValueConverter>();

        builder.Property(x => x.CreditCardId)
            .HasConversion<CreditCardId.EfCoreValueConverter>();
        
        builder.Property(x => x.Limit)
            .HasPrecision(18, 4);
        
        builder.Property(x => x.Threshold)
            .HasPrecision(18, 4);
        
        builder.Property(x => x.DefaultPaymentAmount)
            .HasPrecision(18, 4);
    }
}