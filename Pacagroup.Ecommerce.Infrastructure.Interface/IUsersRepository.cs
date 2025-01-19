using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);
    }
}
