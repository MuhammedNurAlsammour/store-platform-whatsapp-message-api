using MediatR;
using StorePlatform.Application.Dtos.Response;


namespace StorePlatform.Application.Features.Queries.Cart.GetAllCart
{
	public class GetAllCartQueryRequest : IRequest<TransactionResultPack<GetAllCartQueryResponse>>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
