using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee
{
	public class GetByIdEmployeeQueryRequest : IRequest<TransactionResultPack<GetByIdEmployeeQueryResponse>>
	{
		public string Id { get; set; }

	}


}
