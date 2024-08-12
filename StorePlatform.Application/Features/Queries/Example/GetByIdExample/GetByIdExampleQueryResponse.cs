using E = StorePlatform.Domain.Entities;

namespace StorePlatform.Application.Features.Queries.Example.GetByIdExample
{
	public class GetByIdExampleQueryResponse
	{
		public E.ExampleViewModel Example { get; set; }
	}
}
