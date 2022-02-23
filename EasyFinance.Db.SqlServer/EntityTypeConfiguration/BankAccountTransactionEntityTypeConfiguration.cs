using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Db.SqlServer.EntityTypeConfiguration;

public class BankAccountTransactionEntityTypeConfiguration : IEntityTypeConfiguration<BankAccountTransaction>
{
    public void Configure(EntityTypeBuilder<BankAccountTransaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Date)
            .HasColumnType("datetime2(7)");
    }
}