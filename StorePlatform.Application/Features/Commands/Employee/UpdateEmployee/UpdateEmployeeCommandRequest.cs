
using MediatR;
using StorePlatform.Application.Dtos.Response;
using E = StorePlatform.Domain.Entities.EmployeeViewModel;

namespace StorePlatform.Application.Features.Commands.Employee.UpdateEmployee
{
	public class UpdateEmployeeCommandRequest : IRequest<TransactionResultPack<UpdateEmployeeCommandResponse>>
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? TcNo { get; set; }
		public string? Gsm { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }
		public int? Sex { get; set; }

		public Guid? AuthUserId { get; set; }

		public static E Map(E entity, UpdateEmployeeCommandRequest request)
		{


			entity.Name = request.Name ?? entity.Name;
			entity.Surname = request.Surname ?? entity.Surname;
			entity.TcNo = request.TcNo ?? entity.TcNo;
			entity.Gsm = request.Gsm ?? entity.Gsm;
			entity.Email = request.Email ?? entity.Email;
			entity.Address = request.Address ?? entity.Address;
			entity.Sex = request.Sex ?? entity.Sex;
			entity.AuthUserId = request.AuthUserId ?? entity.AuthUserId;


			return entity;
		}
	
	}


}
