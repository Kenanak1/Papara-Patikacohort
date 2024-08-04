using FluentValidation;
using Papara_cohort.Cqrs;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must be greater than 0");
    }
}
            