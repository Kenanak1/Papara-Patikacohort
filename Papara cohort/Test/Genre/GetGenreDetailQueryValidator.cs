using FluentValidation.TestHelper;
using Papara_cohort.Cqrs;
using Xunit;

public class GetGenreDetailQueryTests
{
    private readonly GetGenreByIdQueryValidator _validator;

    public GetGenreDetailQueryTests()
    {
        _validator = new GetGenreByIdQueryValidator();
    }

    [Fact]
    public void Should_Have_Error_When_GenreId_Is_Zero()
    {
        var query = new GetGenreByIdQuery(0);
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.GenreId);
    }

}
