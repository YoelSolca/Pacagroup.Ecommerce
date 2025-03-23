using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetCustomerQuery
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Response<CustomerDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<CustomerDto>();

            var customer = await _unitOfWork.Customers.GetAsync(request.CustomerId);
            response.Data = _mapper.Map<CustomerDto>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }

            return response;
        }
    }
}
