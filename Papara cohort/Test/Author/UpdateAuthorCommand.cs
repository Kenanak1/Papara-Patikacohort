using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class UpdateAuthorCommandTests
{
    private readonly UpdateAuthorCommandValidator _validator;

    public UpdateAuthorCommandTests()
    {
        _validator = new UpdateAuthorCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_AuthorId_Is_Zero()
    {
        var command = new UpdateAuthorCommand(0, new AuthorRequest());
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AuthorId);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var command = new UpdateAuthorCommand(1, new AuthorRequest { Name = string.Empty });
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Request.Name);
    }

}
