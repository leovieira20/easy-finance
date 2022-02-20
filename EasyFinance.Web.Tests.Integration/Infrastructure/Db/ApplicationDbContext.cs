using EasyFinance.Domain.Accounts;
using EasyFinance.Infrastructure.Db.SqlServer.EntityTypeConfiguration;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace EasyFinance.Web.Tests.Integration.Infrastructure.Db;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankAccountEntityConfiguration).Assembly);
    }

    public DbSet<BankAccount> BankAccounts { get; set; } = null!;
    public DbSet<BankAccountTransactions> BankAccountTransactions { get; set; } = null!;
}