using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Queries.Customer.GetByIdCustomer
{
	public class GetByIdCustomerQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdCustomerQueryRequest, GetByIdCustomerQueryResponse>
	{
		public async Task<GetByIdCustomerQueryResponse> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			var customer = await context.Customers
				.Where(x => x.Id == Guid.Parse(request.Id))
				.AsNoTracking()
				.FirstOrDefaultAsync();

			return new()
			{
				Customer = customer
			};
		}
	}
}
