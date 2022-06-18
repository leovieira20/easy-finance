using BankAccountModule.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace BankAccountModule.Db.SqlEventStore;

public class BankAccountEventDbContext : DbContext
{
    protected BankAccountEventDbContext()
    {
    }

    public BankAccountEventDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankAccountEvent>()
            .HasDiscriminator<string>("event_type")
            .HasValue<BankAccountCreated>(nameof(BankAccountCreated))
            .HasValue<BankAccountDepositRegistered>(nameof(BankAccountDepositRegistered))
            .HasValue<BankAccountExpenseRegistered>(nameof(BankAccountExpenseRegistered));

        modelBuilder.Entity<BankAccountCreated>()
            .Property(x => x.Id)
            .HasColumnName("Id");
        
        modelBuilder.Entity<BankAccountCreated>()
            .Property(x => x.EventDate)
            .HasColumnName("EventDate");
        
        modelBuilder.Entity<BankAccountDepositRegistered>()
            .Property(x => x.Id)
            .HasColumnName("Id");
        
        modelBuilder.Entity<BankAccountDepositRegistered>()
            .Property(x => x.EventDate)
            .HasColumnName("EventDate");
        
        modelBuilder.Entity<BankAccountDepositRegistered>()
            .Property(x => x.Amount)
            .HasColumnName("Amount");
        
        modelBuilder.Entity<BankAccountDepositRegistered>()
            .Property(x => x.Description)
            .HasColumnName("Description");
        
        modelBuilder.Entity<BankAccountExpenseRegistered>()
            .Property(x => x.Id)
            .HasColumnName("Id");
        
        modelBuilder.Entity<BankAccountExpenseRegistered>()
            .Property(x => x.EventDate)
            .HasColumnName("EventDate");
        
        modelBuilder.Entity<BankAccountExpenseRegistered>()
            .Property(x => x.Amount)
            .HasColumnName("Amount");
        
        modelBuilder.Entity<BankAccountExpenseRegistered>()
            .Property(x => x.Description)
            .HasColumnName("Description");
    }

    public DbSet<BankAccountEvent> BankAccountEvents { get; set; } = null!;
}