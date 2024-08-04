using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class DeleteAuthorCommandTests
{
    private readonly DeleteAuthorCommandValidator _validator;

    public DeleteAuthorCommandTests()
    {
        _validator = new DeleteAuthorCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_AuthorId_Is_Zero()
    {
        var command = new DeleteAuthorCommand(0);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AuthorId);
    }

}
