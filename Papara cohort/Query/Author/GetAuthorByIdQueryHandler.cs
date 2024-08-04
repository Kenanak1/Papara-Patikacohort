using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.Cqrs;
using Papara_cohort.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, ApiResponse<AuthorResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<AuthorResponse>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await unitOfWork.AuthorRepository.GetById(request.AuthorId);
        if (author == null)
        {
            return new ApiResponse<AuthorResponse>("Author not found");
        }

        var response = mapper.Map<AuthorResponse>(author);
        return new ApiResponse<AuthorResponse>(response);
    }
}
