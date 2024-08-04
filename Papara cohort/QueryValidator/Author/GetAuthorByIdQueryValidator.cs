using FluentValidation;
using Papara_cohort.Cqrs;

public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
{
    public GetAuthorByIdQueryValidator()
    {
        RuleFor(x => x.AuthorId).GreaterThan(0).WithMessage("AuthorId must be greater than 0.");
    }
}
