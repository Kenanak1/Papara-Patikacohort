using FluentValidation;
using Papara_cohort.Cqrs;

public class GetBookDetailQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookDetailQueryValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must be greater than 0");
    }
}