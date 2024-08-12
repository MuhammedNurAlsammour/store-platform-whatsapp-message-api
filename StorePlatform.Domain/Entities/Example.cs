using StorePlatform.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Domain.Entities
{
	public class ExampleViewModel : BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int? Age { get; set; }
	}
}
