using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandHandlar(IEmployeeDbContext context) : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
	{
		public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = CreateProductCommandRequest.Map(request);

			// Add Product to DbContext
			context.Products.Add(product);

			// Save changes to generate ProductId
			await context.SaveChangesAsync(cancellationToken);

			// Now we have ProductId generated
			var productId = product.Id;

			// Create ProductCategory entity
			var productCategory = CreateProductCommandRequest.MapToProductCategory(request, productId);

			// Add ProductCategory to DbContext
			context.ProductCategories.Add(productCategory);

			// Save changes again to save ProductCategory
			await context.SaveChangesAsync(cancellationToken);

			return new CreateProductCommandResponse { StatusCode = (int)HttpStatusCode.Created };
		}
	}


}
