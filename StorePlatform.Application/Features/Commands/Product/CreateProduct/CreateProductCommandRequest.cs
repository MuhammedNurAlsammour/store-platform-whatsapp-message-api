using MediatR;
using E = StorePlatform.Domain.Entities.Product;
using C = StorePlatform.Domain.Entities.ProductCategory;
using StorePlatform.Application.Dtos.Response;



namespace StorePlatform.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandRequest : IRequest<TransactionResultPack<CreateProductCommandResponse>>
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public Guid EmployeeId { get; set; }
		public Guid CategoryId { get; set; } // New Property
		public Guid ProductId { get; set; } 


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

		public static C MapToProductCategory(Guid CategoryId, Guid productId)
		{
			return new()
			{
				CategoryId = CategoryId,
				ProductId = productId,

			};
		}


	}


}
