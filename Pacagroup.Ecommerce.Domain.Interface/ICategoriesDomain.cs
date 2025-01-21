using Pacagroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Interface
{
    public interface ICategoriesDomain
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}
