using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Customer.CreateCustomer
{
	public class CreateCustomerCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateCustomerCommandRequest, TransactionResultPack<CreateCustomerCommandResponse>>
	{
		public async Task<TransactionResultPack<CreateCustomerCommandResponse>> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var customer = CreateCustomerCommandRequest.Map(request);

				await context.Customers.AddAsync(customer);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<CreateCustomerCommandResponse>(
					new CreateCustomerCommandResponse
					{
						StatusCode = (int)HttpStatusCode.Created,
						CustomerId = customer.Id
					},
					customer.Id,
					null,
					"İşlem Başarılı",
					"Müşteri başarıyla eklendi.",
					$"Customer Id: {customer.Id}, başarıyla eklendi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<CreateCustomerCommandResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"Müşteri eklenirken bir hata oluştu.",
					ex.Message
				);
			}
		
		}
	}


}
