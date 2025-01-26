using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
    public interface IDiscountApplication
    {
        Task<Response<bool>> Create(DiscountDto discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken cancellationToken = default);
        Task<Response<bool>> Delete(string id, CancellationToken cancellationToken = default);

        Task<Response<DiscountDto>> Get(int id, CancellationToken cancellationToken = default);
        Task<Response<List<DiscountDto>>> GetAll(CancellationToken cancellationToken = default);
    }
}
