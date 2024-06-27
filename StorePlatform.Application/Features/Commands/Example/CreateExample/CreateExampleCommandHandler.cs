using MediatR;
using StorePlatform.Application.Abstractions.Contexts;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Example.CreateExample
{
	public class CreateExampleCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateExampleCommandRequest, CreateExampleCommandResponse>
	{

		public async Task<CreateExampleCommandResponse> Handle(CreateExampleCommandRequest request, CancellationToken cancellationToken)
		{
			await context.Examples.AddAsync(CreateExampleCommandRequest.Map(request));
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.Created };
		}
	}
}
