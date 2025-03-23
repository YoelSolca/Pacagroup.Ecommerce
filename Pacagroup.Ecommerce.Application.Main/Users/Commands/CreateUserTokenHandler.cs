using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands
{
    public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDto>();

            var user = await _unitOfWork.Users.Authenticate(request.UserName, request.Password);

            if(user == null)
            {
                response.IsSuccess = false;
                response.Message = "Usuario no existe";
                return response;
            }


            response.Data = _mapper.Map<UserDto>(user);
            response.IsSuccess = true;
            response.Message = "Autenticación Exitosa!!!";

            return response;
        }
    }
}
