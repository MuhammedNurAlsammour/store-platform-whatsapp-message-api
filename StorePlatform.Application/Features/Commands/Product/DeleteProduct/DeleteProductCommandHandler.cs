using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Product.DeleteProduct
{
	public class DeleteProductCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteProductCommandRequest, TransactionResultPack<DeleteProductCommandResponse>>
	{

		public async Task<TransactionResultPack<DeleteProductCommandResponse>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var product = await context.Products
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (product == null)
				{
					return ResultFactory.CreateErrorResult<DeleteProductCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Ürün bulunamadı.",
						"Product not found."
					);
				}

				context.Products.Remove(product);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<DeleteProductCommandResponse>(
					new DeleteProductCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					request.Id,
					null,
					"İşlem Başarılı",
					"Ürün başarıyla silindi.",
					$"Product Id: {request.Id}, başarıyla silindi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<DeleteProductCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Ürün silinirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}
