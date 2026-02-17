using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Pacagroup.Ecommerce.Application.Interface;
using System.Reflection;
using System.Runtime.InteropServices;


namespace Pacagroup.Ecommerce.Application.Main;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersApplication, CustomersApplication>();
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
        Console.WriteLine(  );
        return services;
    }
}
            