using StorePlatform.Domain.Entities.Common;


namespace StorePlatform.Domain.Entities
{
	public class ProductCategoryViewModel : BaseEntity
	{

		public Guid ProductId { get; set; }
		public Guid CategoryId { get; set; }

		// Navigation properties
		public ProductViewModel Product { get; set; }
		public CategoryViewModel Category { get; set; }
	}
}
