using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class UpdateGenreCommandTests
{
    private readonly UpdateGenreCommandValidator _validator;

    public UpdateGenreCommandTests()
    {
        _validator = new UpdateGenreCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_GenreId_Is_Zero()
    {
        var command = new UpdateGenreCommand(0, new GenreRequest());
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.GenreId);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var command = new UpdateGenreCommand(1, new GenreRequest { Name = string.Empty });
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Request.Name);
    }

}
