using MediatR;
using StorePlatform.Application.Dtos.Response;


namespace StorePlatform.Application.Features.Commands.Customer.DeleteCustomer
{
	public class DeleteCustomerCommandRequest : IRequest<TransactionResultPack<DeleteCustomerCommandResponse>>
	{
		public string Id { get; set; }
	}
}
