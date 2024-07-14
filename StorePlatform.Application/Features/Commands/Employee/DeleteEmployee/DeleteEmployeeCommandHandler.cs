using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Employee.CreateEmployee;
using StorePlatform.Application.Features.Commands.Example.DeleteExample;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Employee.DeleteEmployee
{
	public class DeleteEmployeeCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteEmployeeCommandRequest, TransactionResultPack<DeleteEmployeeCommandResponse>>
	{
		public async Task<TransactionResultPack<DeleteEmployeeCommandResponse>> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var employee = await context.Employees
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (employee == null)
				{
					return ResultFactory.CreateErrorResult<DeleteEmployeeCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Silinecek çalışan bulunamadı.",
						"Employee not found."
					);
				}

				context.Employees.Remove(employee);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<DeleteEmployeeCommandResponse>(
					new DeleteEmployeeCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					null,
					null,
					"İşlem Başarılı",
					"Çalışan başarıyla Pasflendı.",
					$"Çalışan Id: {employee.Id} başarıyla Pasif."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<DeleteEmployeeCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Çalışan silinirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}
