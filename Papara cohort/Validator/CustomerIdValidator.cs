using FluentValidation;
using Papara_cohort.Models;

public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
{
    public CustomerUpdateDtoValidator()
    {
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
        RuleFor(x => x.Age).InclusiveBetween(18, 150).WithMessage("Age must be between 18 and 150.");
    }
}

public class IdValidator : AbstractValidator<int>
{
    public IdValidator()
    {
        RuleFor(x => x).GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
