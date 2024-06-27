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


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("StorePlatform");
			base.OnModelCreating(modelBuilder);
		}
	}
}
