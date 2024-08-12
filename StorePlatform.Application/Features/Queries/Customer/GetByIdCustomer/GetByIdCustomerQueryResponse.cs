using E = StorePlatform.Domain.Entities;



namespace StorePlatform.Application.Features.Queries.Customer.GetByIdCustomer
{
	public class GetByIdCustomerQueryResponse
	{
		public E.CustomerViewModel Customer { get; set; }

	}
}
