using MediatR;

using E = StorePlatform.Domain.Entities.Example;

namespace StorePlatform.Application.Features.Commands.Example.CreateExample
{
	public class CreateExampleCommandRequest : IRequest<CreateExampleCommandResponse>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int? Age { get; set; }

		public static E Map(CreateExampleCommandRequest request)
		{
			return new()
			{
				Name = request.Name,
				Surname = request.Surname,
				Age = request.Age
			};
		}
	}
}
