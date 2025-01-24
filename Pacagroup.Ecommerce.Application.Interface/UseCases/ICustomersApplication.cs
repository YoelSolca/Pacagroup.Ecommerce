using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
    public interface ICustomersApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(CustomerDto customersDto);
        Response<bool> Update(CustomerDto customersDto);
        Response<bool> Delete(string customerId);
        Response<CustomerDto> Get(string customerId);
        Response<IEnumerable<CustomerDto>> GetAll();
        ResponsePagination<IEnumerable<CustomerDto>> GetaAllWithPagination(int pageNumbrer, int pageSize);

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(CustomerDto customersDto);
        Task<Response<bool>> UpdateAsync(CustomerDto customersDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDto>>> GetaAllWithPaginationAsync(int pageNumbrer, int pageSize);
        #endregion
    }
}
