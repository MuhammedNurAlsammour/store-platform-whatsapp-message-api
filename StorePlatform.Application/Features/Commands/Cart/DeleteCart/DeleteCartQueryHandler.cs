using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Cart.DeleteCart
{

	public class DeleteCartCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteCartCommandRequest, TransactionResultPack<DeleteCartCommandResponse>>
	{
		public async Task<TransactionResultPack<DeleteCartCommandResponse>> Handle(DeleteCartCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var cart = await context.Cart
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (cart == null)
				{
					return ResultFactory.CreateErrorResult<DeleteCartCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Silinecek cart bulunamadı.",
						"cart not found."
					);
				}

				context.Cart.Remove(cart);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<DeleteCartCommandResponse>(
					new DeleteCartCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					null,
					null,
					"İşlem Başarılı",
					"cart başarıyla silindi.",
					$"cart Id: { cart.Id} başarıyla silindi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<DeleteCartCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"cart silinirken bir hata oluştu.",
					ex.Message
				);
			}
		}

	}

}

