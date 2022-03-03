using EasyFinance.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyFinance.Db.SqlServer.EntityTypeConfiguration;

public class CreditCardSettingsEntityConfiguration : IEntityTypeConfiguration<CreditCardSettings>
{
    public void Configure(EntityTypeBuilder<CreditCardSettings> builder)
    {
        builder.HasKey(x => x.Id);
    }
}