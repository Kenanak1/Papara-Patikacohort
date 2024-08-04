using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.Cqrs;
using Papara_cohort.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetById(request.AuthorId);
        if (author == null)
        {
            return new ApiResponse("Author not found");
        }

        mapper.Map(request.Request, author);
        unitOfWork.AuthorRepository.Update(author);
        await unitOfWork.Complete();

        return new ApiResponse();
    }
}
