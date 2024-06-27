using MediatR;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Features.Commands.Employee.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Commands.Customer.CreateCustomer
{
	public class CreateCustomerCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
	{
		public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			await context.Customers.AddAsync(CreateCustomerCommandRequest.Map(request));
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.Created };
		}
	}


}
