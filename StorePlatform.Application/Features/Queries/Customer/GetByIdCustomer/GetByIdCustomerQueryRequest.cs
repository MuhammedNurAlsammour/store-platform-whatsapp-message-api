using MediatR;
using StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Queries.Customer.GetByIdCustomer
{
	public class GetByIdCustomerQueryRequest : IRequest<GetByIdCustomerQueryResponse>
	{
		public string Id { get; set; }
	}
}
