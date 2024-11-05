using E = StorePlatform.Domain.Entities;


namespace StorePlatform.Application.Features.Queries.Employee.GetEmployeeByUserId
{
	public class GetEmployeeByUserIdQueryResponse
	{
		public E.EmployeeViewModel Employees { get; set; }

	}

}
