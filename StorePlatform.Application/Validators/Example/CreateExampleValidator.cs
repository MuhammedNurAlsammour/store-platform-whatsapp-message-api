using FluentValidation;
using StorePlatform.Application.Features.Commands.Example.CreateExample;

namespace StorePlatform.Application.Validators.Example
{

	public class CreateExampleValidator : AbstractValidator<CreateExampleCommandRequest>
	{
		public CreateExampleValidator()
		{
			RuleFor(x => x.Name)
				.NotNull()
					.WithMessage("Name null olamaz.")
			   .NotEmpty()
				   .WithMessage("Lütfen Name'i boş bırakmayınız.")
			   .MaximumLength(10)
				   .WithMessage("Lütfen Name'i 3 ile 10 karakter arasında giriniz.")
			   .MinimumLength(3)
				   .WithMessage("Lütfen Name'i 3 ile 10 karakter arasında giriniz.");

			RuleFor(x => x.Surname)
				.NotNull()
					.WithMessage("Surname null olamaz.")
			   .NotEmpty()
				   .WithMessage("Lütfen Surname'i boş bırakmayınız.")
			   .MaximumLength(20)
				   .WithMessage("Lütfen Surname'i 5 ile 20 karakter arasında giriniz.")
			   .MinimumLength(5)
				   .WithMessage("Lütfen Surname'i 5 ile 20 karakter arasında giriniz.");

			RuleFor(x => x.Age)
			   .GreaterThan(17)
				.WithMessage("Age 18'den küçük olamaz");
		}
	}
}
