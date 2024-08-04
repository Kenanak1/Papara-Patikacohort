using FluentValidation;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Request.BookTitle).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Request.PageCount).GreaterThan(0).WithMessage("PageCount must be greater than 0");
        RuleFor(x => x.Request.PublishedDate).NotEmpty().WithMessage("PublishedDate is required");
    }
}
