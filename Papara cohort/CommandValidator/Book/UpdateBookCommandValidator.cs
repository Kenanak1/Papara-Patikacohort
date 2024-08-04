using FluentValidation;
using Papara_cohort.Cqrs;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must be greater than 0");
        RuleFor(x => x.Request.BookTitle).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Request.PageCount).GreaterThan(0).WithMessage("PageCount must be greater than 0");
        RuleFor(x => x.Request.PublishedDate).NotEmpty().WithMessage("PublishedDate is required");
    }
}