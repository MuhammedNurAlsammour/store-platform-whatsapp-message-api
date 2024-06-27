
using MediatR;

namespace StorePlatform.Application.Features.Commands.Employee.DeleteEmployee
{
	public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>
	{
		public string Id { get; set; }

	}
}
