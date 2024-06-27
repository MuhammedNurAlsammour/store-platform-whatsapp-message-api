using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StorePlatform.Application
{
	public static class ServiceRegistiration
	{
		public static void AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistiration).GetTypeInfo().Assembly));
		}
	}
}
