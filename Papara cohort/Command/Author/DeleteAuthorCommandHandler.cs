using MediatR;
using Papara_cohort.Cqrs;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetById(request.AuthorId);
        if (author == null)
        {
            return new ApiResponse("Author not found");
        }

        await unitOfWork.AuthorRepository.Delete(request.AuthorId);
        await unitOfWork.Complete();

        return new ApiResponse();
    }
}
