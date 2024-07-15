using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Dtos.ResponseDtos.Categorie
{
	public class CategoriesDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
	}
}
