using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Queries.Cart.GetByIdCart
{
	public class GetByIdCartQueryRequest : IRequest<TransactionResultPack<GetByIdCartQueryResponse>>
	{
		public string Id { get; set; }
	}
}
