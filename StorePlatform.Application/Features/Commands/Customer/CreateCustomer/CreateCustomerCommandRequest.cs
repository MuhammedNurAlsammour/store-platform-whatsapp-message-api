using MediatR;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Employee.CreateEmployee;
using E = StorePlatform.Domain.Entities.CustomerViewModel;


namespace StorePlatform.Application.Features.Commands.Customer.CreateCustomer
{
	public class CreateCustomerCommandRequest : IRequest<TransactionResultPack<CreateCustomerCommandResponse>>
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public Guid? AuthUserId { get; set; }



		public static E Map(CreateCustomerCommandRequest request)
		{
			return new()
			{
				Name = request.Name,
				Email = request.Email,
				Phone = request.Phone,
				AuthUserId = request.AuthUserId,
		
			};
		}
	}
	
}
