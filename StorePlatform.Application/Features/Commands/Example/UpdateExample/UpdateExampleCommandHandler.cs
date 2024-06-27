using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Extensions;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Example.UpdateExample
{
	public class UpdateExampleCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateExampleCommandRequest, UpdateExampleCommandResponse>
	{

		public async Task<UpdateExampleCommandResponse> Handle(UpdateExampleCommandRequest request, CancellationToken cancellationToken)
		{
			var example = await context.Examples
				.Where(x => x.Id == Guid.Parse(request.Id))
				.FirstOrDefaultAsync();

			if (example == null) return new() { StatusCode = (int)HttpStatusCode.NotFound };

			UpdateExampleCommandRequest.Map(example, request);
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.OK };
		}
	}
}
