using Dapper;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Persistence.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Persistence.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var query = "Select * from Categories";

            var categories = await connection.QueryAsync<Categories>(query, CommandType.Text);
            return categories;
        }
    }
}
