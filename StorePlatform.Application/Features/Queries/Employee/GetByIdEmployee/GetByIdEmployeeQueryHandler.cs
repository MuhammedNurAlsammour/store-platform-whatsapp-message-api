using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Queries.Employee.GetAllEmployee;
using StorePlatform.Application.Operations;

namespace StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee
{
	public class GetByIdEmployeeQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdEmployeeQueryRequest, TransactionResultPack<GetByIdEmployeeQueryResponse>>
	{
		public async Task<TransactionResultPack<GetByIdEmployeeQueryResponse>> Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var employee = await context.Employees
					.Where(x => x.Id == Guid.Parse(request.Id))
					.AsNoTracking()
					.FirstOrDefaultAsync(cancellationToken);

				if (employee == null)
				{
					return ResultFactory.CreateErrorResult<GetByIdEmployeeQueryResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen çalışan bulunamadı.",
						"Employee not found."
					);
				}

				return ResultFactory.CreateSuccessResult<GetByIdEmployeeQueryResponse>(
					new GetByIdEmployeeQueryResponse
					{
						Employee = employee
					},
					null,
					null,
					"İşlem Başarılı",
					"Çalışan başarıyla getirildi.",
					$"Çalışan Id: {employee.Id} başarıyla getirildi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetByIdEmployeeQueryResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Çalışan getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}

