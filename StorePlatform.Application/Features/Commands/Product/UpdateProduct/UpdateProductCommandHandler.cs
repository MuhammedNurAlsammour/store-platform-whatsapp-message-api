using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using StorePlatform.Domain.Entities;
using System.Net;


namespace StorePlatform.Application.Features.Commands.Product.UpdateProduct
{
	public class UpdateProductCommandHandler(IEmployeeDbContext context) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
	{

		public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);

			if (product == null)
			{
				return new UpdateProductCommandResponse { StatusCode = (int)HttpStatusCode.NotFound };
			}
			product.Name = request.Name;
			product.Description = request.Description;
			product.Price = request.Price;
			product.Stock = request.Stock;
			product.EmployeeId = request.EmployeeId;

			var productCategory = await context.ProductCategories.FirstOrDefaultAsync(pc => pc.ProductId == request.ProductId);
			if (productCategory != null)
			{
				productCategory.CategoryId = request.CategoryId;
			}
			else
			{
				productCategory = new ProductCategory
				{
					ProductId = request.ProductId,
					CategoryId = request.CategoryId
				};
				context.ProductCategories.Add(productCategory);
			}
			await context.SaveChangesAsync(cancellationToken);

			return new UpdateProductCommandResponse { StatusCode = (int)HttpStatusCode.OK };
		}
	}
}
