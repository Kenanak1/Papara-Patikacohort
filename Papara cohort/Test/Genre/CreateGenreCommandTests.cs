using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class CreateGenreCommandTests
{
    private readonly CreateGenreCommandValidator _validator;

    public CreateGenreCommandTests()
    {
        _validator = new CreateGenreCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var command = new CreateGenreCommand(new GenreRequest { Name = string.Empty });
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Request.Name);
    }

}
