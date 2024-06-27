using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;

namespace StorePlatform.Application.Features.Queries.Example.GetByIdExample
{
	public class GetByIdExampleQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetByIdExampleQueryRequest, GetByIdExampleQueryResponse>
	{

		public async Task<GetByIdExampleQueryResponse> Handle(GetByIdExampleQueryRequest request, CancellationToken cancellationToken)
		{
			var example = await context.Examples
				.Where(x => x.Id == Guid.Parse(request.Id))
				.AsNoTracking()
				.FirstOrDefaultAsync();

			return new()
			{
				Example = example
			};
		}
	}
}
