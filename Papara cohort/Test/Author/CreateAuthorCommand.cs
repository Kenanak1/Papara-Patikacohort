using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class CreateAuthorCommandTests
{
    private readonly CreateAuthorCommandValidator _validator;

    public CreateAuthorCommandTests()
    {
        _validator = new CreateAuthorCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var command = new CreateAuthorCommand(new AuthorRequest { Name = string.Empty });
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Request.Name);
    }

}
