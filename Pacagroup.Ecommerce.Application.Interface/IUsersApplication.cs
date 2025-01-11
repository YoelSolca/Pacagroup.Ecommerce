using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
