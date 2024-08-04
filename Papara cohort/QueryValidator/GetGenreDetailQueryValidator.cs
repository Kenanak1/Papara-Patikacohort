using FluentValidation;
using Papara_cohort.Cqrs;

public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
{
    public GetGenreByIdQueryValidator()
    {
        RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("GenreId must be greater than 0.");
    }
}
