using MediatR;
using StorePlatform.Application.Dtos.Response;
using E = StorePlatform.Domain.Entities.CategoryViewModel;


namespace StorePlatform.Application.Features.Commands.Categorie.UpdateCategorie
{
	public class UpdateCategorieCommandRequest : IRequest<TransactionResultPack<UpdateCategorieCommandResponse>>
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }



		public static E Map(E entity, UpdateCategorieCommandRequest request)
		{
			entity.Name = request.Name ?? entity.Name;
			entity.Description = request.Description ?? entity.Description;

			return entity;
		}
	}
}
