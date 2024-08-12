using StorePlatform.Domain.Entities.Common;


namespace StorePlatform.Domain.Entities
{
	public class CartViewModel  : BaseEntity
	{

		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Guid CustomerId { get; set; }
	}
}
