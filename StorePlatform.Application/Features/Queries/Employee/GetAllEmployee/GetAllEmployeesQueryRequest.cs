using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Queries.Employee.GetAllEmployee
{
	public class GetAllEmployeesQueryRequest : IRequest<TransactionResultPack<GetAllEmployeesQueryResponse>>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}


}
