using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Features.Commands.Example.DeleteExample;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Employee.DeleteEmployee
{
	public class DeleteEmployeeCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
	{
		public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
		{

			context.Employees.Remove(await context.Employees
				.Where(x => x.Id == Guid.Parse(request.Id))
				.FirstOrDefaultAsync()
			);
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.OK };
		}
	}

}
