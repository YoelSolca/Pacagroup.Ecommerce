using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }

        public IUsersRepository Users { get; }
        public ICategoriesRepository Categories { get; }

        public IDiscountRepository Discounts { get; }

        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories, IDiscountRepository discounts, ApplicationDbContext applicationDbContext)
        {
            Customers = customers;
            Users = users;
            Categories = categories;
            Discounts = discounts;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        //this -> Objeto actual
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
