using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Interface;

public interface ICustomersApplication
{
    //Importante la clase génerica Response<T> para el manejo de respuestas

    //[Clase Génerica] [Retorna Tipo] [Nombre Método]([Parámetros])

    Task<Response<bool>> InsertAsync(CustomerDto customersDto);
    Task<Response<bool>> UpdateAsync(CustomerDto customersDto);
    Task<Response<bool>> DeleteAsync(string customerId);
    Task<Response<CustomerDto>> GetAsync(string customerId);
    Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
}
