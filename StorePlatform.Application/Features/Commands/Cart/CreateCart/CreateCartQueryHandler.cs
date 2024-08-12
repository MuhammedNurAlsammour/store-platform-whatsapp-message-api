using MediatR;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Cart.CreateCart
{
	public class CreateCartCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateCartCommandRequest, TransactionResultPack<CreateCartCommandResponse>>
	{
		public async Task<TransactionResultPack<CreateCartCommandResponse>> Handle(CreateCartCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var cart = CreateCartCommandRequest.Map(request);
				await context.Cart.AddAsync(cart, cancellationToken);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<CreateCartCommandResponse>(
					new CreateCartCommandResponse
					{
						StatusCode = (int)HttpStatusCode.Created,
						cartId = cart.Id
					},
					null,
					null,
					"İşlem Başarılı",
					"cart başarıyla oluşturuldu.",
					$"cart Id: { cart.Id} başarıyla oluşturuldu."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<CreateCartCommandResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"cart oluşturulurken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}


}
