using E = StorePlatform.Domain.Entities;

namespace StorePlatform.Application.Features.Queries.Example.GetAllExamples
{
	public class GetAllExamplesQueryResponse
	{
		public int TotalCount { get; set; }
		public object Examples { get; set; }
	}
}
