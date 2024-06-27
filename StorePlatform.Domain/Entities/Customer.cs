using StorePlatform.Domain.Entities.Common;

namespace StorePlatform.Domain.Entities
{
	public class Customer: BaseEntity
	{
			public string? Name { get; set; }
			public string? Email { get; set; }
			public string?  Phone {  get; set; }
			public Guid? AuthUserId { get; set; }	
	}
}
