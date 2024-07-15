using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;

namespace StorePlatform.Application.Features.Queries.Categorie.GetByIdCategories
{
	public class GetByIdCategoriesQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdCategoriesQueryRequest, TransactionResultPack<GetByIdCategoriesQueryResponse>>
	{
		public async Task<TransactionResultPack<GetByIdCategoriesQueryResponse>> Handle(GetByIdCategoriesQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{

		
				var category = await context.categories
					.Where(x => x.Id == Guid.Parse(request.Id) && x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.FirstOrDefaultAsync(cancellationToken);

				if (category == null)
				{
					return ResultFactory.CreateErrorResult<GetByIdCategoriesQueryResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen kategori bulunamadı.",
						"Kategori bulunamadı."
					);
				}

				return ResultFactory.CreateSuccessResult<GetByIdCategoriesQueryResponse>(
					new GetByIdCategoriesQueryResponse
					{
						Category = category
					},
					request.Id,
					null,
					"İşlem Başarılı",
					"Kategori başarıyla getirildi.",
					$"Kategori Id: {category.Id} başarıyla getirildi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetByIdCategoriesQueryResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Kategori getirilirken bir hata oluştu.",
					ex.ToString() // Daha fazla detay için
				);
			}
		}

	}



}
