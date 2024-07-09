using Microsoft.EntityFrameworkCore;
using StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Abstractions.Contexts
{

	public interface IEmployeeDbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Example> Examples { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
