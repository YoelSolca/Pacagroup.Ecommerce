using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface ICustomersRepository : IGenericRepository<Customers>
    {
    }
}
