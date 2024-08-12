using E = StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Features.Queries.Cart.GetByIdCart
{
	public class GetByIdCartQueryResponse
	{
		public E.CartViewModel Cart { get; set; }

	}

}
