using FluentValidation;
using Papara_cohort.Model;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be a positive number.");

        RuleFor(x => x.PageCount)
            .GreaterThan(0).WithMessage("Page Count must be a positive number.")
            .LessThanOrEqualTo(99999).WithMessage("Page Count must not exceed 5 digits.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title must not exceed 50 characters.");

        RuleFor(x => x.PublishedDate)
            .NotEmpty().WithMessage("Published Date is required.")
            .Must(BeAValidDate).WithMessage("Published Date must be a valid date.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
