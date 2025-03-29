using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Specifications;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.UpdateCustomerCommand
{
    internal class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var customer = _mapper.Map<Customer>(request);

            /* Uso del patron Specification*/
            var countryInBlackListSpec = new CountryInBlackListSpecification();

            if (!countryInBlackListSpec.IsSatisfiedBy(customer))
            {
                response.IsSuccess = false;
                response.Message = $"Los clientes del pais {customer.Country} no se pueden actualizar porque se encuentra en lista negra.";
                return response;
            }

            response.Data = await _unitOfWork.Customers.UpdateAsync(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización Exitosa!!!";
            }

            return response;
        }
    }
}
