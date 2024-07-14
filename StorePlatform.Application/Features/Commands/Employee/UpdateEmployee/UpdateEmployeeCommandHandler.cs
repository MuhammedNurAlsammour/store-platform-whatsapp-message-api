

using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Employee.UpdateEmployee
{
	public class UpdateEmployeeCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateEmployeeCommandRequest, TransactionResultPack<UpdateEmployeeCommandResponse>>
	{
		public async Task<TransactionResultPack<UpdateEmployeeCommandResponse>> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var employee = await context.Employees
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (employee == null)
				{
					return ResultFactory.CreateErrorResult<UpdateEmployeeCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Güncellenecek çalışan bulunamadı.",
						"Employee not found."
					);
				}

				// Güncellemeleri uygulama
				UpdateEmployeeCommandRequest.Map(employee, request);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<UpdateEmployeeCommandResponse>(
					new UpdateEmployeeCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					null,
					null,
					"İşlem Başarılı",
					"Çalışan başarıyla güncellendi.",
					$"Çalışan Id: {employee.Id} başarıyla güncellendi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<UpdateEmployeeCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Çalışan güncellenirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}


}
