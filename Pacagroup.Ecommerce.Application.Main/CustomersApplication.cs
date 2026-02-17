using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Main;

public class CustomersApplication : ICustomersApplication
{
    //Consume interfaces y no consume implementación directamente

    private readonly ICustomersDomain _customersDomain;
    private readonly IMapper _mapper;

    //En .Net se realiza inyección de dependencia mediante el constructor
    public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
    {
        _customersDomain = customersDomain;
        _mapper = mapper;
    }

    public async Task<Response<bool>> InsertAsync(CustomerDto customersDto)
    {
        var response = new Response<bool>();

        //try llamamos a los métodos de la capa dominio
        try
        {
            //Transferencia de datos entre Customer y customersDto
            var customer = _mapper.Map<Customer>(customersDto); //Mapeo de CustomerDto a Customer

            //Almacenar el resultado obtenido de la capa dominio
            response.Data = await _customersDomain.InsertAsync(customer); // llamamos al método de la capa de dominio

            if(response.Data)
            {
                //Agregamos metadatos a la respuesta
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!!";
            }

        }
        catch (Exception e)
        {
          response.Message = e.Message;
        }

        return response;

    }
    public async Task<Response<bool>> UpdateAsync(CustomerDto customersDto)
    {
        var response = new Response<bool>();

        //try llamamos a los métodos de la capa dominio
        try
        {
            //Transferencia de datos entre Customer y customersDto
            var customer = _mapper.Map<Customer>(customersDto); //Mapeo de CustomerDto a Customer

            //Almacenar el resultado obtenido de la capa dominio
            response.Data = await _customersDomain.UpdateAsync(customer); // llamamos al método de la capa de dominio

            if (response.Data)
            {
                //Agregamos metadatos a la respuesta
                response.IsSuccess = true;
                response.Message = "Actualización Exitosa!!!";
            }
            else 
            {
                response.IsSuccess = true;
                response.Message = $"Cliente {customersDto.CustomerID} no existe !!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
    public async Task<Response<bool>> DeleteAsync(string customerId)
    {
        var response = new Response<bool>();

        //try llamamos a los métodos de la capa dominio
        try
        {
            
            //Almacenar el resultado obtenido de la capa dominio
            response.Data = await _customersDomain.DeleteAsync(customerId); // llamamos al método de la capa de dominio

            if (response.Data)
            {
                //Agregamos metadatos a la respuesta
                response.IsSuccess = true;
                response.Message = "Eliminado correctamente!!!";
            }
            else
            {
                //Agregamos metadatos a la respuesta
                response.IsSuccess = true;
                response.Message = $"Cliente {customerId} no existe !!!";
            }

        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }

    public async Task<Response<CustomerDto>> GetAsync(string customerId)
    {
        var response = new Response<CustomerDto>();

        //try llamamos a los métodos de la capa dominio
        try
        {

            //LLamamos al método de la capa dominio
            var customer = await _customersDomain.GetAsync(customerId);

            //Devolvemos el OBJETO DTO
            response.Data = _mapper.Map<CustomerDto>(customer);

            if (response.Data != null)
            {
                //Agregamos metadatos a la respuesta
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = $"Cliente {customerId} no existe !!!";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
    public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
    {
        // Crear la respuesta de colección 
        var response = new Response<IEnumerable<CustomerDto>>();

        //try llamamos a los métodos de la capa dominio
        try
        {

            //LLamamos al método de la capa dominio
            var customers = await _customersDomain.GetAllAsync();

            //Devolvemos el OBJETO DTO
            response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            if (response.Data != null)
            {
                //Agregamos metadatos a la respuesta
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
            }

        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }



}
