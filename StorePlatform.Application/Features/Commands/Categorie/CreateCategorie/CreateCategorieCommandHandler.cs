using MediatR;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Operations;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Categorie.CreateCategorie
{
	public class CreateCategorieCommandHandler(IEmployeeDbContext context) : IRequestHandler<CreateCategorieCommandRequest, TransactionResultPack<CreateCategorieCommandResponse>>
	{
		public async Task<TransactionResultPack<CreateCategorieCommandResponse>> Handle(CreateCategorieCommandRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var categorie = CreateCategorieCommandRequest.Map(request);

				await context.categories.AddAsync(categorie);
				await context.SaveChangesAsync(cancellationToken);

				return ResultFactory.CreateSuccessResult<CreateCategorieCommandResponse>(
					new CreateCategorieCommandResponse
					{
						StatusCode = (int)HttpStatusCode.Created,
						Id = categorie.Id
					},
					categorie.Id,
					null,
					"İşlem Başarılı",
					"Kategori başarıyla eklendi.",
					$"Kategori Id: {categorie.Id}, başarıyla eklendi."
				);
			}
			catch (Exception ex)
			{
				return ResultFactory.CreateErrorResult<CreateCategorieCommandResponse>(
					null,
					null,
					"Hata / İşlem Başarısız",
					"Kategori eklenirken bir hata oluştu.",
					ex.Message 
				);
			}
		}


	}
}
