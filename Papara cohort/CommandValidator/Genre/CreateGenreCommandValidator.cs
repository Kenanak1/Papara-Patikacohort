using FluentValidation;
using Papara_cohort.Cqrs;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(x => x.Request.Name).NotEmpty().WithMessage("Name is required.");
    }
}
