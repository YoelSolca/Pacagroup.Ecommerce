using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Task<Response<UserDto>> Authenticate(string username, string password);
    }
}
