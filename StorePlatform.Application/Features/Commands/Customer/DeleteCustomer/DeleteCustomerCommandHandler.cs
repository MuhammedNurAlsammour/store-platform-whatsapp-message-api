using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Customer.DeleteCustomer
{
	public class DeleteCustomerCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
	{
		public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
		{

			context.Customers.Remove(await context.Customers
				.Where(x => x.Id == Guid.Parse(request.Id))
				.FirstOrDefaultAsync()
			);
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.OK };
		}
	}

}
