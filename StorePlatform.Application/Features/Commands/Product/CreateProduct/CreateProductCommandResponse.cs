using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandResponse
	{
		public int StatusCode { get; set; }
		public Guid ProductId { get; set; } // New Property
		public Guid CategoryId { get; set; } // New Property
	}
}
