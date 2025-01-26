using Pacagroup.Ecommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<Discount> GetAsync(int id, CancellationToken cancellationToken);

        Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken);
    }
}
