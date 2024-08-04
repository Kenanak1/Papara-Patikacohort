using FluentValidation.TestHelper;
using Papara_cohort.Cqrs;
using Xunit;

public class GetBookDetailQueryTests
{
    private readonly GetBookDetailQueryValidator _validator;

    public GetBookDetailQueryTests()
    {
        _validator = new GetBookDetailQueryValidator();
    }

    [Fact]
    public void Should_Have_Error_When_BookId_Is_Zero()
    {
        var query = new GetBookByIdQuery(0);
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.BookId);
    }

}
