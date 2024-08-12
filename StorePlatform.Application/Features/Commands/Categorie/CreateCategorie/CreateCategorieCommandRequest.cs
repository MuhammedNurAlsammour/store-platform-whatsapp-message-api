using MediatR;
using StorePlatform.Application.Dtos.Response;
using E = StorePlatform.Domain.Entities.CategoryViewModel;

namespace StorePlatform.Application.Features.Commands.Categorie.CreateCategorie
{
	public class CreateCategorieCommandRequest : IRequest<TransactionResultPack<CreateCategorieCommandResponse>>
	{
		public string Name { get; set; }
		public string? Description { get; set; }



		public static E Map(CreateCategorieCommandRequest request)
		{
			return new()
			{
				Name = request.Name,
				Description = request.Description,


			};
		}
	}
}
