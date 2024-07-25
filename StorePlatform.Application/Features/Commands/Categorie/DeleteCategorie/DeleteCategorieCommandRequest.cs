using MediatR;
using StorePlatform.Application.Dtos.Response;

namespace StorePlatform.Application.Features.Commands.Categorie.DeleteCategorie
{

	public class DeleteCategorieCommandRequest : IRequest<TransactionResultPack<DeleteCategorieCommandResponse>>
	{
		public string Id { get; set; }

	}
}
