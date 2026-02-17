using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Dapper;
using System.Runtime.CompilerServices;

namespace Pacagroup.Ecommerce.Infrastructure.Repository;

public class CustomerRepository : ICustomersRepository
{
    // [Modificador de acceso] [readonly] [Tipo] [Identificador]
    private readonly DapperContext _context;

    //    Explicación:
        //private → Solo accesible dentro de la clase.
        //readonly → Solo se asigna una vez (en el constructor).
        //DapperContext → Clase que maneja la conexión a la base de datos.
        //_context → Variable privada que guarda el contexto.

    public CustomerRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();

        //Variable que contiene el método almacenada en Sql
        var query = "CustomersList";

        //El objeto DynamicParameters de Dapper permite mapear
        var parameters = new DynamicParameters();

        //Utilizamos el método QueryAsync de Dapper
        var customers = await connection.QueryAsync<Customer>
            //Parametros
            (
            query,
            //Procedimiento almacenado
            commandType: System.Data.CommandType.StoredProcedure
            );

        return customers;
    }

    public async Task<Customer?> GetAsync(string customerId)
    {
        using var connection = _context.CreateConnection();

        //Variable que contiene el método almacenada en Sql
        var query = "CustomersGetByID";

        //El objeto DynamicParameters de Dapper permite mapear
        var parameters = new DynamicParameters();

        parameters.Add("CustomerID", customerId);


        //Utilizamos el método QuerySingleAsync de Dapper
        var customer = await connection.QuerySingleOrDefaultAsync<Customer>
            //Parametros
            (
            query,
            param: parameters,
            //Procedimiento almacenado
            commandType: System.Data.CommandType.StoredProcedure
            );

        return customer;
    }

    public async Task<bool> InsertAsync(Customer customer)
    {
        using var connection = _context.CreateConnection();

        //Variable que contiene el método almacenada en Sql
        var query = "CustomersInsert";

        //El objeto DynamicParameters de Dapper permite mapear
        var parameters = new DynamicParameters();
        parameters.Add("CustomerId", customer.CustomerID);
        parameters.Add("CompanyName", customer.CompanyName);        
        parameters.Add("ContactName", customer.ContactName);
        parameters.Add("ContactTitle", customer.ContactTitle);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("Region", customer.Region);
        parameters.Add("PostalCode", customer.PostalCode);
        parameters.Add("Country", customer.Country);
        parameters.Add("Phone", customer.Phone);
        parameters.Add("Fax", customer.Fax);

        //El método ExecuteAsync devuelve el número de filas afectadas
        var result = await connection.ExecuteAsync
            //Parametros
            (
            query,
            param: parameters,
            //Procedimiento almacenado
            commandType: System.Data.CommandType.StoredProcedure
            );

        return result > 0;
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        using var connection = _context.CreateConnection();

        //Variable que contiene el método almacenada en Sql
        var query = "CustomersUpdate";

        //El objeto DynamicParameters de Dapper permite mapear
        var parameters = new DynamicParameters();
        parameters.Add("CustomerId", customer.CustomerID);
        parameters.Add("CompanyName", customer.CompanyName);
        parameters.Add("ContactName", customer.ContactName);
        parameters.Add("ContactTitle", customer.ContactTitle);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("Region", customer.Region);
        parameters.Add("PostalCode", customer.PostalCode);
        parameters.Add("Country", customer.Country);
        parameters.Add("Phone", customer.Phone);
        parameters.Add("Fax", customer.Fax);

        //El método ExecuteAsync devuelve el número de filas afectadas
        var result = await connection.ExecuteAsync
            //Parametros
            (
            query,
            param: parameters,
            //Procedimiento almacenado
            commandType: System.Data.CommandType.StoredProcedure
            );

        return result > 0;
    }

    public async Task<bool> DeleteAsync(string customerId)
    {
        using var connection = _context.CreateConnection();

        //Variable que contiene el método almacenada en Sql
        var query = "CustomersDelete";

        //El objeto DynamicParameters de Dapper permite mapear
        var parameters = new DynamicParameters();

        parameters.Add("CustomerID", customerId);


        //El método ExecuteAsync devuelve el número de filas afectadas
        var result = await connection.ExecuteAsync
            //Parametros
            (
            query,
            param: parameters,
            //Procedimiento almacenado
            commandType: System.Data.CommandType.StoredProcedure
            );

        return result > 0;
    }
}
