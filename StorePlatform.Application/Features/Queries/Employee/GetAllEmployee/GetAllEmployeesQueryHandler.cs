using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;


namespace StorePlatform.Application.Features.Queries.Employee.GetAllEmployee
{
	public class GetAllEmployeesQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
	{

		public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
		{
			var totalCount = await context.Employees
				.Where(x => x.RowIsActive && !x.RowIsDeleted)
				.AsNoTracking()
				.CountAsync();

			var employees = await context.Employees
				.Where(x => x.RowIsActive && !x.RowIsDeleted)
				.AsNoTracking()
				.Skip(request.Page * request.Size)
				.Take(request.Size)
				.ToListAsync();

			return new()
			{
				TotalCount = totalCount,
				Employees = employees
			};
		}
	}
}
