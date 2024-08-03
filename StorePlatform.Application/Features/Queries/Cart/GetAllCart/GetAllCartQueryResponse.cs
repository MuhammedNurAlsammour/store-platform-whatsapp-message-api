using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Queries.Cart.GetAllCart
{
	public class GetAllCartQueryResponse
	{
		public int TotalCount { get; set; }
		public object Carts { get; set; }
	}
}
