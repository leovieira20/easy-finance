using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccounts.Db.SqlServer.EF.EntityTypeConfiguration.BankAccount;

public class BankAccountEntityConfiguration : IEntityTypeConfiguration<Domain.Aggregates.BankAccountAggregate.BankAccount>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.BankAccountAggregate.BankAccount> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<BankAccountId.EfCoreValueConverter>();
    }
}