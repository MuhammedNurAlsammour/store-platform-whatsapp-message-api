using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.ResponseDtos.Prodduct;


namespace StorePlatform.Application.Features.Queries.Product.GetByIdProduct
{



	public class GetByIdProductQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
	{
		public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
		{
			var productWithCategory = await context.Products
						.Where(p => p.Id == Guid.Parse(request.Id) && p.RowIsActive && !p.RowIsDeleted)
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
						.FirstOrDefaultAsync(cancellationToken);

			return new GetByIdProductQueryResponse { Product = productWithCategory };
		}
	}



}
