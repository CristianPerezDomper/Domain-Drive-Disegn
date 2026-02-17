using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<DapperContext>();
        services.AddScoped<ICustomersRepository, CustomerRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        

        return services;
    }
}
