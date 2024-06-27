using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Queries.Customer.GetAllCustomer
{
	public class GetAllCustomersQueryRequest : IRequest<GetAllCustomersQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}

}
