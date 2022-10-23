using BankAccountModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccountModule.Db.SqlServer.EF.EntityTypeConfiguration.BankAccount;

public class BankAccountEntityConfiguration : IEntityTypeConfiguration<BankAccountModule.Domain.BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccountModule.Domain.BankAccount> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion<BankAccountId.EfCoreValueConverter>();
    }
}