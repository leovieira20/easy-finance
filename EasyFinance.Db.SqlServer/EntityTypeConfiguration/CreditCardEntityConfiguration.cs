using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Db.SqlServer.EntityTypeConfiguration;

public class CreditCardEntityConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.HasKey(x => x.Id);
    }
}