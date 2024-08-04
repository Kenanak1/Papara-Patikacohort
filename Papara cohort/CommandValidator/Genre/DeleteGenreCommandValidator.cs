using FluentValidation;
using Papara_cohort.Cqrs;

public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("GenreId must be greater than 0.");
    }
}
