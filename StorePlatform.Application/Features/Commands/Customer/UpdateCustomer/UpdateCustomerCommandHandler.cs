using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;

using System.Net;


namespace StorePlatform.Application.Features.Commands.Customer.UpdateCustomer
{
	public class UpdateCustomerCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
	{
		public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			var customer = await context.Customers
				.Where(x => x.Id == Guid.Parse(request.Id))
				.FirstOrDefaultAsync();

			if (customer == null) return new() { StatusCode = (int)HttpStatusCode.NotFound };

			UpdateCustomerCommandRequest.Map(customer, request);
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.OK };
		}
	}

}
