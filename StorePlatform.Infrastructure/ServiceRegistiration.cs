using Microsoft.Extensions.DependencyInjection;
using StorePlatform.Application.Abstractions.RabbitMQ;

namespace StorePlatform.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection services) {
			services.AddSingleton<IRabbitMQService, RabbitMQService>();
		}
	}
}
