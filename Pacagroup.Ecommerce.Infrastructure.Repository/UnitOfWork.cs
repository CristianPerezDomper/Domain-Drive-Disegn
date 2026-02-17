

using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    public ICustomersRepository Customers { get; }

    public UnitOfWork(ICustomersRepository customers)
    {
        Customers = customers;
    }

    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }
}
