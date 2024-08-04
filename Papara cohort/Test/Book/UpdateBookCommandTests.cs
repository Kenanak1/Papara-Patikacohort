using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class UpdateBookCommandTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UpdateBookCommandValidator _validator;

    public UpdateBookCommandTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _validator = new UpdateBookCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_BookId_Is_Zero()
    {
        var command = new UpdateBookCommand(0, new BookRequest());
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BookId);
    }

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var command = new UpdateBookCommand(1, new BookRequest { BookTitle = string.Empty });
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Request.BookTitle);
    }

}
