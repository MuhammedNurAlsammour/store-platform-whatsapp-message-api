using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;


namespace StorePlatform.Application.Features.Queries.Cart.GetAllCart
{
	public class GetAllCartQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllCartQueryRequest, TransactionResultPack<GetAllCartQueryResponse>>
	{

   public async Task<TransactionResultPack<GetAllCartQueryResponse>> Handle(GetAllCartQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var totalCount = await context.Cart
                .Where(x => x.RowIsActive && !x.RowIsDeleted)
                .AsNoTracking()
                .CountAsync(cancellationToken);
            var cart = await context.Cart
                .Where(x => x.RowIsActive && !x.RowIsDeleted)
                .AsNoTracking()
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            return ResultFactory.CreateSuccessResult<GetAllCartQueryResponse>(
                new GetAllCartQueryResponse
                {
                    TotalCount = totalCount,
                    Cart = cart
                },
                null,
                null,
                "İşlem Başarılı",
                "Kartlar başarıyla getirildi.",
                $"{ cart.Count } çalışan başarıyla getirildi."
            );
        }
        catch (Exception ex)
        {
            return ResultFactory.CreateErrorResult<GetAllCartQueryResponse>(
                null,
                null,
                "Hata / İşlem Başarısız",
                "Kartlar getirilirken bir hata oluştu.",
                ex.Message
            );
        }
    }
	}
}
