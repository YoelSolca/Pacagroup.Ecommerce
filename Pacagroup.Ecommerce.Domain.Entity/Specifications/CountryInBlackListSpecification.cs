using Pacagroup.Ecommerce.Domain.Common;
using Pacagroup.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Domain.Specifications
{
    public class CountryInBlackListSpecification : ISpecification<Customer>
    {
        readonly List<string> countriesInBlackList = 
        [
            "Argentina",
            "Brasil", 
            "Chile",
            "Colombia",
            "México",
            "España",
            "Portugal",
            "Estados Unidos",
            "Canadá",
            "Alemania",
        ];


        public bool IsSatisfiedBy(Customer entity)
        {
            return !countriesInBlackList.Contains(entity.Country);
        }
    }
}
