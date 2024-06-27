using E = StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Features.Queries.Employee.GetAllEmployee
{
	public class GetAllEmployeesQueryResponse
	{
		public int TotalCount { get; set; }
		public object Employees { get; set; }
	}
}
