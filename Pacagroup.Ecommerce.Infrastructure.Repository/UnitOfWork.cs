using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }

        public IUsersRepository Users { get; }


        public UnitOfWork(ICustomersRepository customers, IUsersRepository users)
        {
            Customers = customers;
            Users = users;
        }

        //this -> Objeto actual
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
