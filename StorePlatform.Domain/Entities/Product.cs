﻿using StorePlatform.Domain.Entities.Common;

namespace StorePlatform.Domain.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public Guid EmployeeId { get; set; }


		public List<ProductCategory> ProductCategories { get; set; }
	}
}
