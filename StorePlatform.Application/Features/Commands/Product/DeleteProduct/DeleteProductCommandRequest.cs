using MediatR;
using StorePlatform.Application.Dtos.Response;
using StorePlatform.Application.Features.Commands.Example.DeleteExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Commands.Product.DeleteProduct
{

	public class DeleteProductCommandRequest : IRequest<TransactionResultPack<DeleteProductCommandResponse>>
	{
		public string Id { get; set; }
	}
}
