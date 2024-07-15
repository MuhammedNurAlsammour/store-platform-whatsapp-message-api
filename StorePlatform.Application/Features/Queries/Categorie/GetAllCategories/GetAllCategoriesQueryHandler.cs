using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Queries.Categorie.GetAllCategories;
using StorePlatform.Application.Operations;


namespace StorePlatform.Application.Features.Queries.Categorie.GetAllProductCategories
{

	public class GetAllCategoriesQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllCategoriesQueryRequest, TransactionResultPack<GetAllCategoriesQueryResponse>>
	{
		public async Task<TransactionResultPack<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var totalCount = await context.categories
					.Where(x => x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.CountAsync(cancellationToken);

				var categories = await context.categories
					.Where(x => x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.Skip(request.Page * request.Size)
					.Take(request.Size)
					.ToListAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult(
					new GetAllCategoriesQueryResponse
					{
						TotalCount = totalCount,
						Categories = categories
					},
					null, // or any appropriate reference id
					null, // or any appropriate id
					"İşlem Başarılı",
					"Kategori listesi başarıyla getirildi.",
					$"Toplam kategori sayısı: {totalCount}, sayfa: {request.Page}, boyut: {request.Size}."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetAllCategoriesQueryResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"Kategori listesi getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}
