using StorePlatform.Domain.Entities.Common;

namespace StorePlatform.Domain.Entities
{
	public class Employee : BaseEntity
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? TcNo { get; set; }
		public string? Gsm { get; set; }
		public string? Email { get; set; }
		public string? Address { get; set; }

		public int Sex { get; set; }
		public Guid? AuthUserId { get; set; }
	}
}
