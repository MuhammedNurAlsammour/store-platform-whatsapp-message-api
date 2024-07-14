using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using StorePlatform.Domain.Entities;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Product.UpdateProduct
{
	public class UpdateProductCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateProductCommandRequest, TransactionResultPack<UpdateProductCommandResponse>>
	{

		public async Task<TransactionResultPack<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

				if (product == null)
				{
					return ResultFactory.CreateErrorResult<UpdateProductCommandResponse>(
						request.ProductId,
						null,
						"Hata / İşlem Başarısız",
						"Ürün bulunamadı.",
						"Product not found."
					);
				}

				// تحديث معلومات المنتج
				product.Name = request.Name;
				product.Description = request.Description;
				product.Price = request.Price;
				product.Stock = request.Stock;
				product.EmployeeId = request.EmployeeId;

				var productCategory = await context.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == request.ProductId, cancellationToken);
				if (productCategory != null)
				{
					productCategory.CategoryId = request.CategoryId;
				}
				else
				{
					productCategory = new ProductCategory
					{
						ProductId = request.ProductId,
						CategoryId = request.CategoryId
					};
					context.ProductCategories.Add(productCategory);
				}

				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<UpdateProductCommandResponse>(
					new UpdateProductCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					request.ProductId,
					null,
					"İşlem Başarılı",
					"Ürün başarıyla güncellendi.",
					$"Product Id: {product.Id}, veri başarıyla güncellendi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<UpdateProductCommandResponse>(
					request.ProductId,
					null,
					"Hata / İşlem Başarısız",
					"Ürün güncellenirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}
}
