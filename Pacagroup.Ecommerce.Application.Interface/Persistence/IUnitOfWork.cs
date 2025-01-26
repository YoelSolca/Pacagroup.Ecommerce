using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    // IDisposable: Tiene metodos que permite liberar recursos en memoria.
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
        IUsersRepository Users { get; }
        ICategoriesRepository Categories { get; }

        IDiscountRepository Discounts { get; }

        //Persiste los cambios en la base de datos.
        Task<int> Save(CancellationToken cancellationToken);
    }
}
