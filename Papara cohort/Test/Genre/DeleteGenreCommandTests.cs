using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class DeleteGenreCommandTests
{
    private readonly DeleteGenreCommandValidator _validator;

    public DeleteGenreCommandTests()
    {
        _validator = new DeleteGenreCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_GenreId_Is_Zero()
    {
        var command = new DeleteGenreCommand(0);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.GenreId);
    }

}
