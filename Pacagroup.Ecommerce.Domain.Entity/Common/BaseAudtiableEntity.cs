using System;

namespace Pacagroup.Ecommerce.Domain.Common
{
    public abstract class BaseAudtiableEntity: BaseEntity
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set;}
    }
}
