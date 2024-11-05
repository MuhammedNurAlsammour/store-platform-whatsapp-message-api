using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;

namespace StorePlatform.Application.Features.Queries.Employee.GetEmployeeByUserId
{
	public class GetEmployeeByUserIdQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetEmployeeByUserIdQueryRequest, TransactionResultPack<GetEmployeeByUserIdQueryResponse>>
	{
		public async Task<TransactionResultPack<GetEmployeeByUserIdQueryResponse>> Handle(GetEmployeeByUserIdQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var employee = await context.Employees
					.Where(x => x.AuthUserId == Guid.Parse(request.AuthUserId))
					.AsNoTracking()
					.FirstOrDefaultAsync(cancellationToken);

				if (employee == null)
				{
					return ResultFactory.CreateErrorResult<GetEmployeeByUserIdQueryResponse>(
						request.AuthUserId,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen Personel  bulunamadı.",
                        "Personel bulunamadı."
                    );
				}

				return ResultFactory.CreateSuccessResult<GetEmployeeByUserIdQueryResponse>(
					new GetEmployeeByUserIdQueryResponse
					{
						Employees = employee
					},
					null,
					null,
					"İşlem Başarılı",
                    "Personel başarıyla getirildi.",
					$"Personel Adı: { employee.Name} başarıyla getirildi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetEmployeeByUserIdQueryResponse>(
					request.AuthUserId,
					null,
					"Hata / İşlem Başarısız",
                    "Personel getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}

