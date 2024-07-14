

namespace StorePlatform.Application.Dtos.ResponseDtos.Customer
{
	public class CustomerDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public Guid? AuthUserId { get; set; }
	}
}
