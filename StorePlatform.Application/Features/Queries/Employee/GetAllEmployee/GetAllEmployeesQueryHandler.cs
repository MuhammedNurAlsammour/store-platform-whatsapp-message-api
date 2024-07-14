using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Customer.UpdateCustomer;
using StorePlatform.Application.Operations;


namespace StorePlatform.Application.Features.Queries.Employee.GetAllEmployee
{
	public class GetAllEmployeesQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllEmployeesQueryRequest, TransactionResultPack<GetAllEmployeesQueryResponse>>
	{

		public async Task<TransactionResultPack<GetAllEmployeesQueryResponse>> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var totalCount = await context.Employees
					.Where(x => x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.CountAsync(cancellationToken);

				var employees = await context.Employees
					.Where(x => x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.Skip(request.Page * request.Size)
					.Take(request.Size)
					.ToListAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<GetAllEmployeesQueryResponse>(
					new GetAllEmployeesQueryResponse
					{
						TotalCount = totalCount,
						Employees = employees
					},
					null,
					null,
					"İşlem Başarılı",
					"Çalışanlar başarıyla getirildi.",
					$"{employees} çalışan başarıyla getirildi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetAllEmployeesQueryResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"Çalışanlar getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}
}
