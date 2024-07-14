using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Product.CreateProduct;
using StorePlatform.Application.Operations;

namespace StorePlatform.Application.Features.Queries.Customer.GetAllCustomer
{
	public class GetAllCustomersQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllCustomersQueryRequest, TransactionResultPack<GetAllCustomersQueryResponse>>

	{
		public async Task<TransactionResultPack<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var totalCount = await context.Customers
					.Where(x => x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.CountAsync(cancellationToken);

				var customers = await context.Customers
					.Where(x => x.RowIsActive && !x.RowIsDeleted)
					.AsNoTracking()
					.Skip(request.Page * request.Size)
					.Take(request.Size)
					.ToListAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<GetAllCustomersQueryResponse>(
					new GetAllCustomersQueryResponse
					{
						TotalCount = totalCount,
						Customers = customers
					},
					null, // or any appropriate reference id
					null, // or any appropriate id
					"İşlem Başarılı",
					"Müşteri listesi başarıyla getirildi.",
					$"Toplam müşteri sayısı: {totalCount}, sayfa: {request.Page}, boyut: {request.Size}."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<GetAllCustomersQueryResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"Müşteri listesi getirilirken bir hata oluştu.",
					ex.Message
				);
			}
		}
		
	}
}
