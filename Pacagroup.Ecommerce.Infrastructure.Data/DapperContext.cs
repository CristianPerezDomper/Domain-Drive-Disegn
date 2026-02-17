using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Pacagroup.Ecommerce.Infrastructure.Data;

public class DapperContext
{

    //ICondiguration.-  Es una interfaz de ASP.NET Core que permite 
    //acceder a la configuración de la aplicación

    //[Modificador de acceso] [Inmutabilidad] [tipo] [nombre de variable]
    private readonly IConfiguration _configuration;

    private readonly string? _connectionString;


    //Inyección de dependencia

    //[Modificador de acceso] [Nombre del método] [Parámetro]
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;

        //Obtiene la cadena de conexión llamada DefaultConnection
        //El valor proviene normalmente de appsettings.json
        //Se guarda en la variable _connectionString para usarla al conectar
        //a la base de datos con Dapper.

        _connectionString = _configuration.GetConnectionString("NorthwindConnection");
    }

    // [Modificador de acceso] [Tipo de retorno] [Nombre del método] ()
    public IDbConnection CreateConnection()
        
        // => → Expresión lambda / método de una sola línea
        //Se usa cuando el método tiene una única instrucción.
        //new SqlConnection(_connectionString)
        //Crea una nueva conexión a SQL Server.
        //Usa la cadena de conexión almacenada en _connectionString.
        
        => new SqlConnection(_connectionString);


}
