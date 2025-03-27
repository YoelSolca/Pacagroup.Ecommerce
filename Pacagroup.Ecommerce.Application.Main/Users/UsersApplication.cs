using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Users
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper iMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = iMapper;
        }
        public async Task<Response<UserDto>> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();

            var user = await _unitOfWork.Users.Authenticate(username, password);
            response.Data = _mapper.Map<UserDto>(user);
            response.IsSuccess = true;
            response.Message = "Autenticación Exitosa!!!";

            return response;
        }
    }
}
