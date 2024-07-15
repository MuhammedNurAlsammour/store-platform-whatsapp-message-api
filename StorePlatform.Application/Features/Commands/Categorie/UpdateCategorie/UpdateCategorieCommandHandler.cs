using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Employee.UpdateEmployee;
using StorePlatform.Application.Operations;
using StorePlatform.Domain.Entities;
using System.Net;



namespace StorePlatform.Application.Features.Commands.Categorie.UpdateCategorie
{

	public class UpdateCategorieCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateCategorieCommandRequest, TransactionResultPack<UpdateCategorieCommandResponse>>
	{
		public async Task<TransactionResultPack<UpdateCategorieCommandResponse>> Handle(UpdateCategorieCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var category = await context.categories
					.Where(x => x.Id == Guid.Parse(request.Id))
					.FirstOrDefaultAsync(cancellationToken);

				if (category == null)
				{
					return ResultFactory.CreateErrorResult<UpdateCategorieCommandResponse>(
						request.Id,
						null,
						"Hata / İşlem Başarısız",
						"Belirtilen kategori bulunamadı.",
						"Kategori bulunamadı."
					);
				}

				UpdateCategorieCommandRequest.Map(category, request);

				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<UpdateCategorieCommandResponse>(
					new UpdateCategorieCommandResponse
					{
						StatusCode = (int)HttpStatusCode.OK
					},
					null,
					null,
					"İşlem Başarılı",
					"Kategori başarıyla güncellendi.",
					$"Kategori Id: {category.Id} başarıyla güncellendi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<UpdateCategorieCommandResponse>(
					request.Id,
					null,
					"Hata / İşlem Başarısız",
					"Kategori güncellenirken bir hata oluştu.",
					ex.Message
				);
			}

		}
	}

}