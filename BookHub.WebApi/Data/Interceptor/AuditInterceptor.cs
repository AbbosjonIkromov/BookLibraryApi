﻿using BookHub.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookHub.WebApi.Data.Interceptor
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditFields(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        private void UpdateAuditFields(DbContext? context)
        {
            if (context is null) return;

            var entries = context.ChangeTracker
                .Entries()
                .Where(r => r.Entity is IAuditable);

            foreach (var entry in entries)
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedTime = DateTime.UtcNow;
                }
            }
        }
    }
}
