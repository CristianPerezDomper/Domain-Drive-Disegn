using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Domain.Interface;

public interface ICustomersDomain
{
    /*Método asíncrono se hace uso de clase task
     *Devuelve un booleano --- Recibe como parametro la entidad customer*/
    Task<bool> InsertAsync(Customer customer);             
    Task<bool> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(string customerId);

    /*Devuelve la entidad customer --- Recibe como parametro customerId*/
    Task<Customer> GetAsync(string customerId);


    /*Devuelve una colección de la entidad customer --- No recibe parametro*/
    Task<IEnumerable<Customer>> GetAllAsync();


}
