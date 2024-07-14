using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandHandlar(IEmployeeDbContext context) : IRequestHandler<CreateProductCommandRequest, TransactionResultPack<CreateProductCommandResponse>>
	{
		public async Task<TransactionResultPack<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				// التحقق من وجود الفئة
				var categoryExists = await context.categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);
				if (!categoryExists)
				{
					return ResultFactory.CreateErrorResult<CreateProductCommandResponse>(
						request.CategoryId,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen kategori bulunamadı.",
						"Category not found."
					);
				}

				var product = CreateProductCommandRequest.Map(request);

				context.Products.Add(product);
				await context.SaveChangesAsync(cancellationToken);

				var productId = product.Id;
				var categoryId = request.CategoryId;

				await context.ProductCategories.AddAsync(CreateProductCommandRequest.MapToProductCategory(categoryId, productId));
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<CreateProductCommandResponse>(
					new CreateProductCommandResponse
					{
						StatusCode = (int)HttpStatusCode.Created,
						CategoryId = categoryId,
						ProductId = productId
					},
					null, // or any appropriate reference id
					null, // or any appropriate id
					"İşlem Başarılı",
					"Kayıt başarıyla eklendi.",
					$"Product Id: {product.Id}, veri başarıyla eklendi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<CreateProductCommandResponse>(
					request.CategoryId,
					null,
					"Hata / İşlem Başarısız",
					"Kayıt eklenirken bir hata oluştu.",
					ex.Message
				);
			}
		}

	}


}
