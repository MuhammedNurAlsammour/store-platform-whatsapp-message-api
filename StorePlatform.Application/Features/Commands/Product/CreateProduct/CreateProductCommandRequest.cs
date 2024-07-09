using MediatR;
using E = StorePlatform.Domain.Entities.Product;
using C = StorePlatform.Domain.Entities.ProductCategory;



namespace StorePlatform.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public Guid EmployeeId { get; set; }
		public Guid CategoryId { get; set; } // New Property
		public Guid ProductId { get; set; } // New Property


		public static E Map(CreateProductCommandRequest request)
		{
			return new()
			{
				Name = request.Name,
				Description = request.Description,
				Price = request.Price,
				Stock = request.Stock,
				EmployeeId = request.EmployeeId,
		
			};
		}

		public static C MapToProductCategory(CreateProductCommandRequest request, Guid productId)
		{
			return new()
			{
				CategoryId = request.CategoryId,
				ProductId = productId,



			};
		}


	}


}
