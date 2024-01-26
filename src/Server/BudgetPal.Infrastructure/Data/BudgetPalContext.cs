using Microsoft.EntityFrameworkCore;

namespace BudgetPal.Infrastructure.Data;

public class BudgetPalContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConnectionStringProvider connectionStringProvider = new PostgresConnectionStringProvider();
        optionsBuilder.UseNpgsql(connectionStringProvider.GetConnectionString());
    }
}