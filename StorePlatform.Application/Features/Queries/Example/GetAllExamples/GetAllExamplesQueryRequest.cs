using MediatR;

namespace StorePlatform.Application.Features.Queries.Example.GetAllExamples
{
	public class GetAllExamplesQueryRequest : IRequest<GetAllExamplesQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
