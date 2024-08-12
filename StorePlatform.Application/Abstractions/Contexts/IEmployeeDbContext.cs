using Microsoft.EntityFrameworkCore;
using StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Abstractions.Contexts
{

	public interface IEmployeeDbContext
	{
		public DbSet<EmployeeViewModel> Employees { get; set; }
		public DbSet<ExampleViewModel> Examples { get; set; }
		public DbSet<CustomerViewModel> Customers { get; set; }
		public DbSet<ProductViewModel> Products { get; set; }
		public DbSet<CategoryViewModel> categories { get; set; }
		public DbSet<ProductCategoryViewModel> ProductCategories { get; set; }
		public DbSet<CartViewModel> Cart { get; set; }


		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
