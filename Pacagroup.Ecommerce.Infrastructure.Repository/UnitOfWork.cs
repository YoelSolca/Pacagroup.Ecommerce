using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }

        public IUsersRepository Users { get; }
        public ICategoriesRepository Categories { get; }


        public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories)
        {
            Customers = customers;
            Users = users;
            Categories = categories;    
        }

        //this -> Objeto actual
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
