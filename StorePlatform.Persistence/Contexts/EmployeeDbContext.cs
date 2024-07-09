using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Domain.Entities;

namespace StorePlatform.Persistence.Contexts
{
	public class EmployeeDbContext : DbContext, IEmployeeDbContext
	{
		public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Example> Examples { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> categories { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("StorePlatform");
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProductCategory>()
				.ToTable("product_categories");

			modelBuilder.Entity<ProductCategory>()
				.HasKey(pc => new { pc.ProductId, pc.CategoryId });

			modelBuilder.Entity<ProductCategory>()
				.HasOne(pc => pc.Product)
				.WithMany(p => p.ProductCategories)
				.HasForeignKey(pc => pc.ProductId);

			modelBuilder.Entity<ProductCategory>()
				.HasOne(pc => pc.Category)
				.WithMany(c => c.ProductCategories)
				.HasForeignKey(pc => pc.CategoryId);
		}



	}
}
