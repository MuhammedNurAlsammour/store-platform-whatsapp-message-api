using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Queries.Product.GetAllProducts
{
	

	public class GetAllProductsQueryRequest : IRequest<TransactionResultPack<GetAllProductsQueryResponse>>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
