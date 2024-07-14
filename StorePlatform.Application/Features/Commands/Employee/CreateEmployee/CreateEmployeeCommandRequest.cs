using MediatR;
using StorePlatform.Application.Dtos.Response;
using E = StorePlatform.Domain.Entities.Employee;

namespace StorePlatform.Application.Features.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandRequest : IRequest<TransactionResultPack<CreateEmployeeCommandResponse>>
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string? TcNo { get; set; }
		public string? Gsm { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }
		public int Sex { get; set; }
		public Guid? AuthUserId { get; set; }




		public static E Map(CreateEmployeeCommandRequest request)
		{
			return new()
			{
				Name = request.Name,
				Surname = request.Surname,
				TcNo = request.TcNo, 
				Gsm = request.Gsm,
				Email = request.Email,
				Address = request.Address,
				Sex = request.Sex,
				AuthUserId = request.AuthUserId,
			};
		}
	}


}
