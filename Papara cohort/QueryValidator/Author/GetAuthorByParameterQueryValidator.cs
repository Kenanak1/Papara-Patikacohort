using FluentValidation;
using Papara_cohort.Cqrs;

public class GetAuthorByParameterQueryValidator : AbstractValidator<GetAuthorByParameterQuery>
{
    public GetAuthorByParameterQueryValidator()
    {
        RuleFor(x => x.AuthorId).GreaterThan(0).WithMessage("AuthorId must be greater than 0.");
        RuleFor(x => x.AuthorName).NotEmpty().WithMessage("AuthorName is required.");
    }
}
