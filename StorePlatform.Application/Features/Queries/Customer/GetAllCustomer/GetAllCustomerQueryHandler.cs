using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;

namespace StorePlatform.Application.Features.Queries.Customer.GetAllCustomer
{
	public class GetAllCustomersQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersQueryResponse>

	{
		public async Task<GetAllCustomersQueryResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
		{
			var totalCount = await context.Customers
				.Where(x => x.RowIsActive && !x.RowIsDeleted)
				.AsNoTracking()
			.CountAsync();

			var customers = await context.Customers
				.Where(x => x.RowIsActive && !x.RowIsDeleted)
				.AsNoTracking()
				.Skip(request.Page * request.Size)
				.Take(request.Size)
				.ToListAsync();

			return new GetAllCustomersQueryResponse
			{
				TotalCount = totalCount,
				Customers = customers
			};
		}
	}
}
