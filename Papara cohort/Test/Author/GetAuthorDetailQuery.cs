using FluentValidation.TestHelper;
using Papara_cohort.Cqrs;
using Xunit;

public class GetAuthorDetailQueryTests
{
    private readonly GetAuthorByIdQueryValidator _validator;

    public GetAuthorDetailQueryTests()
    {
        _validator = new GetAuthorByIdQueryValidator();
    }

    [Fact]
    public void Should_Have_Error_When_AuthorId_Is_Zero()
    {
        var query = new GetAuthorByIdQuery(0);
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(x => x.AuthorId);
    }

}
