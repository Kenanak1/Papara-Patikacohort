using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.Cqrs;
using Papara_cohort.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;
using Papara_cohort.Model;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ApiResponse<AuthorResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<AuthorResponse>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = mapper.Map<Author>(request.Request);
        await unitOfWork.AuthorRepository.Insert(author);
        await unitOfWork.Complete();

        var response = mapper.Map<AuthorResponse>(author);
        return new ApiResponse<AuthorResponse>(response);
    }
}
