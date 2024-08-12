﻿using MediatR;
using StorePlatform.Application.Features.Commands.Product.CreateProduct;
using E = StorePlatform.Domain.Entities.ProductViewModel;
using C = StorePlatform.Domain.Entities.ProductCategoryViewModel;
using StorePlatform.Domain.Entities;
using StorePlatform.Application.Dtos.Response;
namespace StorePlatform.Application.Features.Commands.Product.UpdateProduct
{
	public class UpdateProductCommandRequest : IRequest<TransactionResultPack<UpdateProductCommandResponse>>
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public Guid EmployeeId { get; set; }
		public Guid CategoryId { get; set; } 

		public static E MapToProduct(UpdateProductCommandRequest request)
		{
			return new E
			{
				Id = request.ProductId,
				Name = request.Name,
				Description = request.Description,
				Price = request.Price,
				Stock = request.Stock,
				EmployeeId = request.EmployeeId
			};
		}

		public static C MapToProductCategory(UpdateProductCommandRequest request, Guid productId)
		{
			return new C
			{
				CategoryId = request.CategoryId,
				ProductId = productId
			};
		}
	}
}
