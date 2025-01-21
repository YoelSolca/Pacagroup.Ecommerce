using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CategoriesDomain : ICategoriesDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _unitOfWork.Categories.GetAll();
        }
    }
}
