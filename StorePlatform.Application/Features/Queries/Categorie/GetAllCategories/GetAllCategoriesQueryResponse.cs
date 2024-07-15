using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Queries.Categorie.GetAllProductCategories
{
	public class GetAllCategoriesQueryResponse
	{
		public int TotalCount { get; set; }
		public object Categories { get; set; }
	}
}
