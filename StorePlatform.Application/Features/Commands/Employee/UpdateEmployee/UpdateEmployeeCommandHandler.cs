

using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Features.Commands.Example.UpdateExample;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Employee.UpdateEmployee
{
	public class UpdateEmployeeCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
	{
		public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			var example = await context.Employees
				.Where(x => x.Id == Guid.Parse(request.Id))
				.FirstOrDefaultAsync();

			if (example == null) return new() { StatusCode = (int)HttpStatusCode.NotFound };

			UpdateEmployeeCommandRequest.Map(example, request);
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.OK };
		}
	}


}
