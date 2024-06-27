using MediatR;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;

namespace StorePlatform.Application.Features.Queries.Example.GetAllExamples
{
	public class GetAllExamplesQueryHandler(IEmployeeDbContext context) : IRequestHandler<GetAllExamplesQueryRequest, GetAllExamplesQueryResponse>
	{

		public async Task<GetAllExamplesQueryResponse> Handle(GetAllExamplesQueryRequest request, CancellationToken cancellationToken)
		{
			var totalCount = await context.Examples
				.Where(x => x.RowIsActive && !x.RowIsDeleted)
				.AsNoTracking()
				.CountAsync();

			var examples = await context.Examples
				.Where(x => x.RowIsActive && !x.RowIsDeleted)
				.AsNoTracking()
				.Skip(request.Page * request.Size)
				.Take(request.Size)
				.ToListAsync();

			return new()
			{
				TotalCount = totalCount,
				Examples = examples
			};
		}
	}
}
