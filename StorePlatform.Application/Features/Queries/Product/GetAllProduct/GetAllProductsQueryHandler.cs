using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Enums;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Dtos.ResponseDtos.Prodduct;
using StorePlatform.Application.Operations;
using StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Features.Queries.Product.GetAllProducts
{


    public class GetAllProductsQueryHandler(IEmployeeDbContext _context) : IRequestHandler<GetAllProductsQueryRequest, TransactionResultPack<GetAllProductsQueryResponse>>

    {


        public async Task<TransactionResultPack<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var totalCount = await _context.Products
                    .Where(x => x.RowIsActive && !x.RowIsDeleted)
                    .AsNoTracking()
                    .CountAsync(cancellationToken);

                var productsWithCategories = await _context.Products
                    .Where(x => x.RowIsActive && !x.RowIsDeleted)
                    .Join(_context.ProductCategories,
                        p => p.Id,
                        pc => pc.ProductId,
                        (p, pc) => new { p, pc })
                    .Join(_context.categories,
                        ppc => ppc.pc.CategoryId,
                        c => c.Id,
                        (ppc, c) => new ProductDTO
                        {
                            ProductId = ppc.p.Id,
                            ProductName = ppc.p.Name,
                            ProductDescription = ppc.p.Description,
                            ProductPrice = ppc.p.Price,
                            ProductStock = ppc.p.Stock,
                            ProductCreatedDate = ppc.p.RowCreatedDate,
                            ProductUpdatedDate = ppc.p.RowUpdatedDate,
                            ProductIsActive = ppc.p.RowIsActive,
                            ProductIsDeleted = ppc.p.RowIsDeleted,
                            ProductEmployeeId = ppc.p.EmployeeId,
                            CategoryId = c.Id,
                            CategoryName = c.Name,
                            CategoryDescription = c.Description
                        })
                    .AsNoTracking()
                    .Skip(request.Page * request.Size)
                    .Take(request.Size)
                    .ToListAsync(cancellationToken);

                var response = new GetAllProductsQueryResponse() { Products = productsWithCategories };

                return new TransactionResultPack<GetAllProductsQueryResponse>
                {
                    Result = response,
                    OperationResult = new TransactionResult
                    {
                        Result = TransactionResultEnm.Success,
                        MessageTitle = "İşlem Başarılı",
                        MessageContent = "Görev listesi başarıyla getirildi.",
                        MessageDetail = $"Toplam Görev Veri Sayısı: {totalCount}",
                        ReferenceId = totalCount
                    }
                };
            }
            catch (Exception ex)
            {
                return new TransactionResultPack<GetAllProductsQueryResponse>
                {
                    Result = null,
                    OperationResult = new TransactionResult
                    {
                        Result = TransactionResultEnm.Error,
                        MessageTitle = "Hata / İşlem Başarısız",
                        MessageContent = "Görev listesi verileri getirilemedi.",
                        MessageDetail = ex.Message,
                        ReferenceId = 0 // Can set 0 or any appropriate value in case of failure
                    }
                };
            }
        }
    }
}
