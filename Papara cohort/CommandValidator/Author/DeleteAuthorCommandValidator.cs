using FluentValidation;
using Papara_cohort.Cqrs;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(x => x.AuthorId).GreaterThan(0).WithMessage("AuthorId must be greater than 0.");
    }
}
