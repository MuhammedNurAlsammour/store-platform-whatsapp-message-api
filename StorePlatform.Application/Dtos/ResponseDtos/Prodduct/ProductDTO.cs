

namespace StorePlatform.Application.Dtos.ResponseDtos.Prodduct
{
	public class ProductDTO
	{
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public int ProductStock { get; set; }
		public DateTime ProductCreatedDate { get; set; }
		public DateTime ProductUpdatedDate { get; set; }
		public bool ProductIsActive { get; set; }
		public bool ProductIsDeleted { get; set; }
		public Guid ProductEmployeeId { get; set; }
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
	}
}
