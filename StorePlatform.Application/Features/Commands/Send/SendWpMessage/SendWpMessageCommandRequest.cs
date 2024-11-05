using MediatR;
using StorePlatform.Application.Dtos.Response;
using E = StorePlatform.Domain.Entities.EmployeeViewModel;

namespace StorePlatform.Application.Features.Commands.Send.SendWpMessage
{
	public class SendWpMessageCommandRequest : IRequest<TransactionResultPack<SendWpMessageCommandResponse>>
	{

		public string Phone { get; set; }
		public string Message { get; set; }
		public int WaitTime { get; set; }
	}


}
