using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Queries.Categorie.GetByIdCategories
{
	public class GetByIdCategoriesQueryRequest : IRequest<TransactionResultPack<GetByIdCategoriesQueryResponse>>
	{
		public string Id { get; set; }
	}
}
