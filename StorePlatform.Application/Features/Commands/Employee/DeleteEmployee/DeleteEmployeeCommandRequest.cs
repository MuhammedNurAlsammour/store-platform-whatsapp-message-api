
using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Commands.Employee.DeleteEmployee
{
	public class DeleteEmployeeCommandRequest : IRequest<TransactionResultPack<DeleteEmployeeCommandResponse>>
	{
		public string Id { get; set; }

	}
}
