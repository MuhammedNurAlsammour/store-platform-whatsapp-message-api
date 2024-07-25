using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;

namespace StorePlatform.Application.Features.Commands.Categorie.DeleteCategorie
{

	public class DeleteCategorieCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteCategorieCommandRequest, TransactionResultPack<DeleteCategorieCommandResponse>>
	{
		public async Task<TransactionResultPack<DeleteCategorieCommandResponse>> Handle(DeleteCategorieCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var category = await context.categories
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (category == null)
				{
					return ResultFactory.CreateErrorResult<DeleteCategorieCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Silinecek kategori bulunamadı.",
						"Category not found."
					);
				}

				context.categories.Remove(category);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<DeleteCategorieCommandResponse>(
					new DeleteCategorieCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					null,
					null,
					"İşlem Başarılı",
					"Kategori başarıyla silindi.",
					$"Kategori Id: {category.Id} başarıyla silindi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<DeleteCategorieCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Kategori silinirken bir hata oluştu.",
					ex.Message
				);
			}
		}

	}

}
