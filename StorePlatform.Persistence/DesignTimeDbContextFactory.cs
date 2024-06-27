using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StorePlatform.Persistence.Contexts;

namespace StorePlatform.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmployeeDbContext>
	{
		public EmployeeDbContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "../StorePlatform.API/"))
			.AddJsonFile("appsettings.json")
			.Build();

			DbContextOptionsBuilder<EmployeeDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));

			return new(dbContextOptionsBuilder.Options);

		}
	}
}
