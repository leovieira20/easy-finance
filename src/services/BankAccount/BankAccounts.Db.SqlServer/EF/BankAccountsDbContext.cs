using BankAccounts.Domain.Aggregates.BankAccountAggregate;
using BankAccounts.Domain.Aggregates.BankAccountTransactionAggregate;
using BankAccounts.Db.SqlServer.EF.EntityTypeConfiguration.BankAccount;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Db.SqlServer.EF;

public class BankAccountsDbContext : DbContext
{
    public BankAccountsDbContext()
    {
    }

    public BankAccountsDbContext(DbContextOptions<BankAccountsDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAccountEntityConfiguration).Assembly);
    }

    public DbSet<BankAccount> BankAccounts { get; set; } = null!;
    public DbSet<BankAccountTransaction> BankAccountTransactions { get; set; } = null!;
}