namespace BudgetPal.Infrastructure.Data;

public interface IConnectionStringProvider
{
    public string GetConnectionString();
}

public class PostgresConnectionStringProvider : IConnectionStringProvider
{
    public string GetConnectionString()
    {
        string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        string username = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres";
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";
        string database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "postgres";
        return $"Host={host};Database=${database};Username={username};Password={password}";
    }
}