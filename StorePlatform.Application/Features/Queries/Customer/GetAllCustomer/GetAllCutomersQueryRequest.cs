using MediatR;
using StorePlatform.Application.Dtos.Response;


namespace StorePlatform.Application.Features.Queries.Customer.GetAllCustomer
{
	public class GetAllCustomersQueryRequest : IRequest<TransactionResultPack<GetAllCustomersQueryResponse>>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}

}
