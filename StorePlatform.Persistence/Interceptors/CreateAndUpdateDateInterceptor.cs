using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StorePlatform.Domain.Entities.Common;

namespace StorePlatform.Persistence.Interceptors
{
	public sealed class CreateAndUpdateDateInterceptor : SaveChangesInterceptor
	{

		public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
		{
			DbContext? context = eventData.Context;

			if (context is null)
				return base.SavingChangesAsync(eventData, result, cancellationToken);

			var baseEntityDatas = context.ChangeTracker.Entries<BaseEntity>();

			foreach (var data in baseEntityDatas)
			{
				switch (data.State)
				{
					case EntityState.Added:
						data.Entity.RowCreatedDate = DateTime.UtcNow;
						data.Entity.RowIsActive = true;
						data.Entity.RowIsDeleted = false;
						break;
					case EntityState.Modified:
						data.Entity.RowUpdatedDate = DateTime.UtcNow;
						break;
					case EntityState.Deleted:
						data.Entity.RowIsActive = false;
						data.Entity.RowIsDeleted = true;
						data.State = EntityState.Modified;
						break;
					default:
						break;
				}
			}

			return base.SavingChangesAsync(eventData, result, cancellationToken);
		}
	}
}
