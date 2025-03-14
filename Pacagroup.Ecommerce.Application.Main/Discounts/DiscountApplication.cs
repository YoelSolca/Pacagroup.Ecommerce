using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Infrastructure;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Events;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Discounts
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DiscountDtoValidator _discountDtoValidator;
        private readonly IEventBus _eventBus;
        public DiscountApplication(IUnitOfWork unitOfWork, IMapper mapper, DiscountDtoValidator discountDtoValidator, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _discountDtoValidator = discountDtoValidator;
            _eventBus = eventBus;
        }

        public async Task<Response<bool>> Create(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validationResult = await _discountDtoValidator.ValidateAsync(discountDto, cancellationToken);
                if (!validationResult.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Error = validationResult.Errors;
                    return response;
                }

                var discount = _mapper.Map<Discount>(discountDto);
                await _unitOfWork.Discounts.InsertAsync(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";

                    // Publicar evento
                    var discountCreatedEvent = _mapper.Map<DiscountCreatedEvent>(discount);
                    _eventBus.Publish(discountCreatedEvent);

                }
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<DiscountDto>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<DiscountDto>();
            try
            {
                var discount = await _unitOfWork.Discounts.GetAsync(id, cancellationToken);

                if (discount is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Descuento no existe...";
                    return response;
                }

                response.Data = _mapper.Map<DiscountDto>(discount);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<List<DiscountDto>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<DiscountDto>>();
            try
            {
                var discounts = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<DiscountDto>>(discounts);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validationResult = await _discountDtoValidator.ValidateAsync(discountDto, cancellationToken);
                if (!validationResult.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Error = validationResult.Errors;
                    return response;
                }

                var discount = _mapper.Map<Discount>(discountDto);
                await _unitOfWork.Discounts.UpdateAsync(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                await _unitOfWork.Discounts.DeleteAsync(id.ToString());
                response.Data = await _unitOfWork.Save(cancellationToken) > 0;

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<DiscountDto>>();

            try
            {
                var count = await _unitOfWork.Discounts.CountAsync();

                var discounts = await _unitOfWork.Discounts.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<DiscountDto>>(discounts);
                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;

                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}
