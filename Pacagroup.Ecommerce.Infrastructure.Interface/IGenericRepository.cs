namespace Pacagroup.Ecommerce.Infrastructure.Interface;

// [Interfaz] [Genérica] [Restricción] T sea una clase    
public interface IGenericRepository<T> where T : class
{

    // Método InsertAsync: recibe un objeto y lo guarda, devuelve true si fue exitoso
    Task<bool> InsertAsync(T entity);

    // Método UpdateAsync: actualiza un objeto existente, devuelve true si fue exitoso
    Task<bool> UpdateAsync(T entity);

    // Método DeleteAsync: elimina un registro por id, devuelve true si fue exitoso
    Task<bool> DeleteAsync(string customerId);

    // Método GetAsync con parámetros string, devuelve un objeto genérico o nulo
    Task<T?> GetAsync(string customerId);

    // Método GetAllAsync: obtiene y devuelve todos los registros en una lista
    Task<IEnumerable<T>> GetAllAsync();
}
