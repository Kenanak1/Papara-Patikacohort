using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Moq;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Xunit;

public class DeleteBookCommandTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DeleteBookCommandValidator _validator;

    public DeleteBookCommandTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _validator = new DeleteBookCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_BookId_Is_Zero()
    {
        var command = new DeleteBookCommand(0);
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BookId);
    }

}
