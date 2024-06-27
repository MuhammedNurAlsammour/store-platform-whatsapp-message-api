using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;

namespace StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee
{
	public class GetByIdEmployeeQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
	{
		public async Task<GetByIdEmployeeQueryResponse> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
		{
			var employee = await context.Employees
				.Where(x => x.Id == Guid.Parse(request.Id))
				.AsNoTracking()
				.FirstOrDefaultAsync();

			return new()
			{
				Employee = employee
			};
		}
	}

}

