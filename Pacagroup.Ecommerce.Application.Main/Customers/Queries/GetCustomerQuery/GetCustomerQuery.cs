using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetCustomerQuery
{
    public sealed record class GetCustomerQuery : IRequest<Response<CustomerDto>>
    {
        public string CustomerId { get; set; }
    }
}
