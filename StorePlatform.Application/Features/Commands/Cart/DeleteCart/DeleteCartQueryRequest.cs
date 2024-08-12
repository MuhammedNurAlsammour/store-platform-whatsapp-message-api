using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Commands.Cart.DeleteCart
{
	public class DeleteCartCommandRequest : IRequest<TransactionResultPack<DeleteCartCommandResponse>>
	{
		public string Id { get; set; }
	}
}

