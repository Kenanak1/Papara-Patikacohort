using FluentValidation;
using Papara_cohort.DTO;
using Papara_cohort.Cqrs;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Request.Name).NotEmpty().WithMessage("Author name is required.");
        RuleFor(x => x.Request.DateOfBirth).LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");
    }
}
