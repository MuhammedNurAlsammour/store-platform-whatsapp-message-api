using MediatR;
using StorePlatform.Application.Abstractions.Contexts;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
	{
		public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			await context.Employees.AddAsync(CreateEmployeeCommandRequest.Map(request));
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.Created };
		}
	}

	
}
