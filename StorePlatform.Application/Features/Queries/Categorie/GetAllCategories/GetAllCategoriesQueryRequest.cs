using MediatR;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Queries.Categorie.GetAllProductCategories;

namespace StorePlatform.Application.Features.Queries.Categorie.GetAllCategories
{
	public class GetAllCategoriesQueryRequest : IRequest<TransactionResultPack<GetAllCategoriesQueryResponse>>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
