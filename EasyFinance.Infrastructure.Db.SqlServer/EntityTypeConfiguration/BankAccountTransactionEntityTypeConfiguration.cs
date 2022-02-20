using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Infrastructure.Db.SqlServer.EntityTypeConfiguration;

public class BankAccountTransactionEntityTypeConfiguration : IEntityTypeConfiguration<BankAccountTransactions>
{
    public void Configure(EntityTypeBuilder<BankAccountTransactions> builder)
    {
        builder.HasKey(x => x.Id);
    }
}