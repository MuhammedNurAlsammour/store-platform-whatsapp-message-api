using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Employee.CreateEmployee
{
	public class CreateEmployeeCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateEmployeeCommandRequest, TransactionResultPack<CreateEmployeeCommandResponse>>
	{
		public async Task<TransactionResultPack<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var employee = CreateEmployeeCommandRequest.Map(request);
				await context.Employees.AddAsync(employee, cancellationToken);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<CreateEmployeeCommandResponse>(
					new CreateEmployeeCommandResponse
					{
						StatusCode = (int)HttpStatusCode.Created,
						EmployeeId = employee.Id // Assuming you want to return the created employee's ID
					},
					null,
					null,
					"İşlem Başarılı",
					"Çalışan başarıyla oluşturuldu.",
					$"Çalışan Id: {employee.Id} başarıyla oluşturuldu."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<CreateEmployeeCommandResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"Çalışan oluşturulurken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

	
}
