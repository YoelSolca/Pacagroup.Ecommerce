using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pacagroup.Ecommerce.Application.Interface.Presentation;
using Pacagroup.Ecommerce.Domain.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Persistence.Interceptors
{
    public class AuditableEntitySaveChangesIntercetor : SaveChangesInterceptor
    {
        public readonly ICurrentUser _currentUser;

        public AuditableEntitySaveChangesIntercetor(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;
            foreach (var entry in context.ChangeTracker.Entries<BaseAudtiableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUser.UserName;
                    entry.Entity.Created = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUser.UserName;
                    entry.Entity.LastModified = DateTime.Now;
                }
            }
        }
    }
}
