using BankAccountModule.Domain;
using CreditCardModule.Domain;
using EasyFinance.Db.SqlServer.EF.EntityTypeConfiguration.BankAccount;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Db.SqlServer;

public class EasyFinanceDbContext : DbContext
{
    public EasyFinanceDbContext()
    {
    }

    public EasyFinanceDbContext(DbContextOptions<EasyFinanceDbContext> options) 
        : base(options)
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