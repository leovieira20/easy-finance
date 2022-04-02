using BankAccountModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Db.SqlServer.EF.EntityTypeConfiguration.BankAccount;

public class BankAccountTransactionEntityTypeConfiguration : IEntityTypeConfiguration<BankAccountTransaction>
{
    public void Configure(EntityTypeBuilder<BankAccountTransaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<BankAccountTransactionId.EfCoreValueConverter>();

        builder.Property(x => x.BankAccountId)
            .HasConversion<BankAccountId.EfCoreValueConverter>();

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);
        
        builder.Property(x => x.CalculationAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.Date)
            .HasColumnType("datetime2(7)");
    }
}