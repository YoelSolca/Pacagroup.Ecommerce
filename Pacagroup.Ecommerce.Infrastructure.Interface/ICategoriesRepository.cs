using Pacagroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}
