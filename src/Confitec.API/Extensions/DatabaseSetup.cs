using Confitec.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Confitec.API.Extensions;

public static class DatabaseSetup
{
public static IServiceCollection AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Confitec.API")
                          .EnableRetryOnFailure()));

            return services;
        }
}
