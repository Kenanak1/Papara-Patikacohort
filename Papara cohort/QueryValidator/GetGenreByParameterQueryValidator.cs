using FluentValidation;
using Papara_cohort.Cqrs;

public class GetGenreByParameterQueryValidator : AbstractValidator<GetGenreByParameterQuery>
{
    public GetGenreByParameterQueryValidator()
    {
        RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("GenreId must be greater than 0.");
        RuleFor(x => x.GenreName).NotEmpty().WithMessage("GenreName is required.");
    }
}
