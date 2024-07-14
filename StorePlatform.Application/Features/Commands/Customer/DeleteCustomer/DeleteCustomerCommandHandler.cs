using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Customer.DeleteCustomer
{
	public class DeleteCustomerCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteCustomerCommandRequest, TransactionResultPack<DeleteCustomerCommandResponse>>
	{
		public async Task<TransactionResultPack<DeleteCustomerCommandResponse>> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var customer = await context.Customers
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (customer == null)
				{
					return ResultFactory.CreateErrorResult<DeleteCustomerCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen müşteri bulunamadı.",
						"Customer not found."
					);
				}

				context.Customers.Remove(customer);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<DeleteCustomerCommandResponse>(
					new DeleteCustomerCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					request.Id,
					null,
					"İşlem Başarılı",
					"Müşteri başarıyla silindi.",
					$"Customer Id: {customer.Id} başarıyla silindi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<DeleteCustomerCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Müşteri silinirken bir hata oluştu.",
					ex.Message
				);
			}
		}
	}

}
