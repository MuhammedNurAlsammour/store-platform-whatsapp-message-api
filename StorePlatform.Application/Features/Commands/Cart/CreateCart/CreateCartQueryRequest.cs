using MediatR;
using StorePlatform.Application.Dtos.Response;
using E = StorePlatform.Domain.Entities.CartViewModel;

namespace StorePlatform.Application.Features.Commands.Cart.CreateCart
{
	public class CreateCartCommandRequest : IRequest<TransactionResultPack<CreateCartCommandResponse>>
	{



		public Guid ProductId { get; set; }//TODO: yapılacak
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid CustomerId { get; set; }

		public static E Map(CreateCartCommandRequest request)
		{
			return new()
			{
				ProductId = request.ProductId,
				Quantity = request.Quantity,
				Price = request.Price,
				CustomerId = request.CustomerId,

			};
		}
	}


}
