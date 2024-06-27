using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Application.Abstractions.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Application.Features.Commands.Example.DeleteExample
{
	public class DeleteExampleCommandHandler(IEmployeeDbContext context) : IRequestHandler<DeleteExampleCommandRequest, DeleteExampleCommandResponse>
	{

		public async Task<DeleteExampleCommandResponse> Handle(DeleteExampleCommandRequest request, CancellationToken cancellationToken)
		{

			context.Examples.Remove(await context.Examples
				.Where(x => x.Id == Guid.Parse(request.Id))
				.FirstOrDefaultAsync()
			);
			await context.SaveChangesAsync(cancellationToken);

			return new() { StatusCode = (int)HttpStatusCode.OK };
		}
	}
}
