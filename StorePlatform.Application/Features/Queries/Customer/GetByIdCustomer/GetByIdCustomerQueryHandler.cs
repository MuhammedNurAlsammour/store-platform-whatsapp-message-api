using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Queries.Employee.GetByIdEmployee;
using StorePlatform.Application.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Queries.Customer.GetByIdCustomer
{
	public class GetByIdCustomerQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdCustomerQueryRequest, TransactionResultPack<GetByIdCustomerQueryResponse>>
	{
		public async Task<TransactionResultPack<GetByIdCustomerQueryResponse>> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var customer = await context.Customers
					.Where(x => x.Id == Guid.Parse(request.Id) && x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.FirstOrDefaultAsync(cancellationToken);

				if (customer == null)
				{
					return ResultFactory.CreateErrorResult<GetByIdCustomerQueryResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen müşteri bulunamadı.",
						"Customer not found."
					);
				}

				return ResultFactory.CreateSuccessResult<GetByIdCustomerQueryResponse>(
					new GetByIdCustomerQueryResponse
					{
						Customer = customer
					},
					request.Id,
					null,
					"İşlem Başarılı",
					"Müşteri başarıyla getirildi.",
					$"Customer Id: {customer.Id} başarıyla getirildi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetByIdCustomerQueryResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Müşteri getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}
}
