using System;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    // IDisposable: Tiene metodos que permite liberar recursos en memoria.
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
    }
}
