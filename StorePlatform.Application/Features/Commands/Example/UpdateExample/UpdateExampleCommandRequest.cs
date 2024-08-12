using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = StorePlatform.Domain.Entities.ExampleViewModel;

namespace StorePlatform.Application.Features.Commands.Example.UpdateExample
{
	public class UpdateExampleCommandRequest : IRequest<UpdateExampleCommandResponse>
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public int? Age { get; set; }

		public static E Map(E entity, UpdateExampleCommandRequest request)
		{
			entity.Name = request.Name ?? entity.Name;
			entity.Surname = request.Surname ?? entity.Surname;
			entity.Age = request.Age ?? entity.Age;

			return entity;
		}
	}
}
