using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Dtos.ResponseDtos.Prodduct;
using StorePlatform.Application.Operations;
using StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Features.Queries.Product.GetAllProducts
{
	

	public class GetAllProductsQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllProductsQueryRequest, TransactionResultPack<GetAllProductsQueryResponse>>

	{

	
		public async Task<TransactionResultPack<GetAllProductsQueryResponse>>  Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
						var totalCount = await context.Products
					   .Where(x => x.RowIsActive && !x.RowIsDeleted)
					   .AsNoTracking()
					   .CountAsync(cancellationToken);

					var productsWithCategories = await context.Products
						.Where(x => x.RowIsActive && !x.RowIsDeleted)
						.Join(context.ProductCategories,
							p => p.Id,
							pc => pc.ProductId,
							(p, pc) => new { p, pc })
						.Join(context.categories,
							ppc => ppc.pc.CategoryId,
							c => c.Id,
							(ppc, c) => new ProductDTO
							{
								ProductId = ppc.p.Id,
								ProductName = ppc.p.Name,
								ProductDescription = ppc.p.Description,
								ProductPrice = ppc.p.Price,
								ProductStock = ppc.p.Stock,
								ProductCreatedDate = ppc.p.RowCreatedDate,
								ProductUpdatedDate = ppc.p.RowUpdatedDate,
								ProductIsActive = ppc.p.RowIsActive,
								ProductIsDeleted = ppc.p.RowIsDeleted,
								ProductEmployeeId = ppc.p.EmployeeId,
								CategoryId = c.Id,
								CategoryName = c.Name,
								CategoryDescription = c.Description
							})
						.AsNoTracking()
						.Skip(request.Page * request.Size)
						.Take(request.Size)
						.ToListAsync(cancellationToken);


				
				return ResultFactory.CreateSuccessResult<GetAllProductsQueryResponse>(
			  new GetAllProductsQueryResponse() { Products = productsWithCategories },
			  productsWithCategories.Count(),
			  null,
			  "İşlem Başarılı",
			  "Görev listesi getirildi.",
			  $"Toplam Görev Veri Sayısı:{productsWithCategories.Count()} "
			  //$"sayfa : {request.Pagination.Page} ve boyut : {request.Pagination.Size} " +
			  //$"arasındaki toplam veri sayısı : {StaffDisplayList.Count}, şeklinde getirildi"
			  );

			}
            catch (Exception ex)
            {
                return ResultFactory.CreateErrorResult<GetAllProductsQueryResponse>(false, null,
                   "Hata / İşlem Başarısız",
                   "Görev Listesi verileriniz Getirilemedi",
                   ex.Message);
            }
		}
	}
}
