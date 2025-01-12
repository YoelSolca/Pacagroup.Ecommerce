﻿using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _userDtoValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper iMapper, UsersDtoValidator userDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = iMapper;
            _userDtoValidator = userDtoValidator;
        }
        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _userDtoValidator.Validate(new UsersDto { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Errores de validación.";
                response.Error = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
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
