using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands
{
    public sealed record CreateUserTokenCommand : IRequest<Response<UserDto>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
