using MediatR;


namespace StorePlatform.Application.Features.Commands.Customer.DeleteCustomer
{
	public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
	{
		public string Id { get; set; }
	}
}
