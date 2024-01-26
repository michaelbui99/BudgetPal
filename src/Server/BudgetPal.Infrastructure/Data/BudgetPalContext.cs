using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPal.Infrastructure.Data;

public class BudgetPalContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Budget> Budgets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConnectionStringProvider connectionStringProvider = new PostgresConnectionStringProvider();
        optionsBuilder.UseNpgsql(connectionStringProvider.GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<CurrencyCode>();
        modelBuilder.Entity<Currency>().HasKey(c => c.Code);
        modelBuilder.Entity<MoneyAmount>().HasKey(ma => new { ma.Amount, ma.CurrencyCode });
        modelBuilder.Entity<Account>().HasOne(a => a.Balance);
    }
}