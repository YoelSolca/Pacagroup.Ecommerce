using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Transversal.Common;
using System;

namespace Pacagroup.Ecommerce.Application.UseCases.Users
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper iMapper, UsersDtoValidator usersDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = iMapper;
            _usersDtoValidator = usersDtoValidator;
        }
        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            var validation = _usersDtoValidator.Validate(new UserDto() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Error = validation.Errors;
                return response;
            }
            try
            {
                var user = _unitOfWork.Users.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
