using StorePlatform.Domain.Entities.Common;


namespace StorePlatform.Domain.Entities
{
	public class CategoryViewModel : BaseEntity
	{
		public string Name { get; set; }
		public string? Description { get; set; }

		public List<ProductCategoryViewModel> ProductCategories { get; set; }
	}
}
