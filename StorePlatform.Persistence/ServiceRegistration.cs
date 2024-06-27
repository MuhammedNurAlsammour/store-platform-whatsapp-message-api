using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Persistence.Contexts;
using StorePlatform.Persistence.Interceptors;

namespace StorePlatform.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<CreateAndUpdateDateInterceptor>();

			services.AddDbContext<EmployeeDbContext>((sp, options) =>
			{
				var createAndUpdateDateInterceptor = sp.GetRequiredService<CreateAndUpdateDateInterceptor>();

				options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"))
					.UseSnakeCaseNamingConvention()
					.AddInterceptors(createAndUpdateDateInterceptor);

			}, ServiceLifetime.Scoped);


			services.AddScoped<IEmployeeDbContext, EmployeeDbContext>();


		}
	}
}