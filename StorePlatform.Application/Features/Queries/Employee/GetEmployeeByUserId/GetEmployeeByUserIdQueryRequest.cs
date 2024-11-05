using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Queries.Employee.GetEmployeeByUserId
{
	public class GetEmployeeByUserIdQueryRequest : IRequest<TransactionResultPack<GetEmployeeByUserIdQueryResponse>>
	{
		public string AuthUserId { get; set; }
	}
}
