using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;


public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo 
            {
                Version = "v1",
                Title = "Pacagroup Technology Services API Market",
                Description = "A simple example ASP.NET Core Web API.",
                TermsOfService = new Uri("https://pacagroup.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Cristian Pérez",
                    Email = "cristian.perez.domper@gmail.com",
                    Url = new Uri("https://pacagroup.com/contact"),
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://pacagroup.com/license"),
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            c.EnableAnnotations();
        });

        return services;
    }
}



