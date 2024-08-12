using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Domain.Entities;
using StorePlatform.Domain.Maps;

namespace StorePlatform.Persistence.Contexts
{
	public class EmployeeDbContext : DbContext, IEmployeeDbContext
	{
		public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

		public DbSet<EmployeeViewModel> Employees { get; set; }
		public DbSet<ExampleViewModel> Examples { get; set; }
		public DbSet<CustomerViewModel> Customers { get; set; }
		public DbSet<ProductViewModel> Products { get; set; }
		public DbSet<CategoryViewModel> categories { get; set; }
		public DbSet<ProductCategoryViewModel> ProductCategories { get; set; }
		public DbSet<CartViewModel> Cart { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("StorePlatform");
			base.OnModelCreating(modelBuilder);


			modelBuilder.ApplyConfiguration(new ProductCategoryMap());
			modelBuilder.ApplyConfiguration(new CartMap());

		}
	}




}
