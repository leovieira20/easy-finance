using EasyFinance.Db.SqlServer.EF.EntityTypeConfiguration;
using EasyFinance.Domain.Accounts;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Db.SqlServer.EF;

public class EasyFinanceDbContext : DbContext
{
    public EasyFinanceDbContext()
    {
    }

    public EasyFinanceDbContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAccountEntityConfiguration).Assembly);
    }

    public DbSet<BankAccount> BankAccounts { get; set; } = null!;
    public DbSet<BankAccountTransaction> BankAccountTransactions { get; set; } = null!;
    public DbSet<CreditCard> CreditCards { get; set; } = null!;
    public DbSet<CreditCardTransaction> CreditCardTransactions { get; set; } = null!;
}