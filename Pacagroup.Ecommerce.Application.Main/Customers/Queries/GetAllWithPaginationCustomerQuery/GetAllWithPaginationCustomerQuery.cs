using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery
{
    public sealed record GetAllWithPaginationCustomerQuery : IRequest<ResponsePagination<IEnumerable<CustomerDto>>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
