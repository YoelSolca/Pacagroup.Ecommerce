using System;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    // IDisposable: Tiene metodos que permite liberar recursos en memoria.
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
        ICategoriesRepository Categories { get; }
    }
}
