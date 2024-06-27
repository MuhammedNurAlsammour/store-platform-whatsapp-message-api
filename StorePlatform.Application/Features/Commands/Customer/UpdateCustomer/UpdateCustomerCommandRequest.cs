using MediatR;
using E = StorePlatform.Domain.Entities.Customer;


namespace StorePlatform.Application.Features.Commands.Customer.UpdateCustomer
{
	public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public Guid? AuthUserId { get; set; }


		public static E Map(E entity, UpdateCustomerCommandRequest request)
		{

			entity.Name = request.Name ?? entity.Name;
			entity.Email = request.Email ?? entity.Email;
			entity.Phone = request.Phone ?? entity.Phone;
			entity.AuthUserId = request.AuthUserId ?? entity.AuthUserId;
		


			return entity;
		}
	}



}
