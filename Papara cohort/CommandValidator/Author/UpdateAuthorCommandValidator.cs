using FluentValidation;
using Papara_cohort.Cqrs;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(x => x.AuthorId).GreaterThan(0).WithMessage("AuthorId must be greater than 0.");
        RuleFor(x => x.Request.Name).NotEmpty().WithMessage("Author name is required.");
        RuleFor(x => x.Request.DateOfBirth).LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");
    }
}
