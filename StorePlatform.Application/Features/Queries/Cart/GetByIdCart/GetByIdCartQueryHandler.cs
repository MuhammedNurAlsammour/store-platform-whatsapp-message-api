using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;

namespace StorePlatform.Application.Features.Queries.Cart.GetByIdCart
{
	public class GetByIdCartQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdCartQueryRequest, TransactionResultPack<GetByIdCartQueryResponse>>
	{
		public async Task<TransactionResultPack<GetByIdCartQueryResponse>> Handle(GetByIdCartQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var cart = await context.Cart
					.Where(x => x.Id == Guid.Parse(request.Id))
					.AsNoTracking()
					.FirstOrDefaultAsync(cancellationToken);

				if (cart == null)
				{
					return ResultFactory.CreateErrorResult<GetByIdCartQueryResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen çalışan bulunamadı.",
						"Employee not found."
					);
				}

				return ResultFactory.CreateSuccessResult<GetByIdCartQueryResponse>(
					new GetByIdCartQueryResponse
					{
						Cart = cart
					},
					null,
					null,
					"İşlem Başarılı",
					"Çalışan başarıyla getirildi.",
					$"Çalışan Id: { cart.Id} başarıyla getirildi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetByIdCartQueryResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Çalışan getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}

