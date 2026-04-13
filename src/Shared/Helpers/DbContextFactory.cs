using Microsoft.EntityFrameworkCore;
using Gestion_vuelos.src.Shared.Context;

namespace Gestion_vuelos.src.Shared.Helpers;

public static class DbContextFactory
{
    public static DbContextOptions<AppDbContext> CreateOptions(string connectionString, Version version)
    {
        return new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(version))
            .Options;
    }
}