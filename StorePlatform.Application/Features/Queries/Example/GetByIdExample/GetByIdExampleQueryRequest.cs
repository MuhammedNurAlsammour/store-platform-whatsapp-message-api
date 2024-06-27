using MediatR;

namespace StorePlatform.Application.Features.Queries.Example.GetByIdExample
{
	public class GetByIdExampleQueryRequest : IRequest<GetByIdExampleQueryResponse>
	{
		public string Id { get; set; }
	}
}
