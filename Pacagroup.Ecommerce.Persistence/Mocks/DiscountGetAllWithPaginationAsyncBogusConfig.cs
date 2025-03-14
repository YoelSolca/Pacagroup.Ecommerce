using Bogus;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Enums;

namespace Pacagroup.Ecommerce.Persistence.Mocks
{
    public class DiscountGetAllWithPaginationAsyncBogusConfig : Faker<Discount>
    {
        public DiscountGetAllWithPaginationAsyncBogusConfig()
        {
            RuleFor(x => x.Id, f => f.IndexFaker + 1);
            RuleFor(x => x.Name, f => f.Commerce.ProductName());
            RuleFor(x => x.Description, f => f.Commerce.ProductDescription());
            RuleFor(x => x.Percent, f => f.Random.Int(70,90));
            RuleFor(x => x.Status, f => f.PickRandom<DiscountStatus>());
        }
    }
}
