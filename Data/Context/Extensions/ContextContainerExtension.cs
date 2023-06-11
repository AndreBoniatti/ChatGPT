using Microsoft.EntityFrameworkCore;

namespace PPI.Data.Context.Extensions;

public static class ContextContainerExtension
{
    public static IServiceCollection AddDataContext(this IServiceCollection services, string dbConnection)
    => services.AddDbContext<DataContext>(options =>
    {
        options.UseNpgsql(dbConnection);
        options.EnableSensitiveDataLogging();
        options.UseLazyLoadingProxies();
    });
}

