using CreditCardModule.Db.SqlServer.EF.EntityTypeConfiguration.CreditCard;
using CreditCardModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace CreditCardModule.Db.SqlServer.EF;

public class CreditCardsDbContext : DbContext
{
    public CreditCardsDbContext()
    {
    }

    public CreditCardsDbContext(DbContextOptions<CreditCardsDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreditCardEntityConfiguration).Assembly);
    }

    public DbSet<CreditCard> CreditCards { get; set; } = null!;
    public DbSet<CreditCardTransaction> CreditCardTransactions { get; set; }
}