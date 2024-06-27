using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = StorePlatform.Domain.Entities.Example;

namespace StorePlatform.Application.Features.Commands.Example.DeleteExample
{
	public class DeleteExampleCommandRequest : IRequest<DeleteExampleCommandResponse>
	{
		public string Id { get; set; }
	}
}
