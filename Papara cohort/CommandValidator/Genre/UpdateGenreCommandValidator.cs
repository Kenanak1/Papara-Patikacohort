using FluentValidation;
using Papara_cohort.Cqrs;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("GenreId must be greater than 0.");
        RuleFor(x => x.Request.Name).NotEmpty().WithMessage("Name is required.");
    }
}
