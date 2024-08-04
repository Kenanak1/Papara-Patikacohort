using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.Cqrs;
using Papara_cohort.UnitOfWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, ApiResponse<List<AuthorResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllAuthorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<AuthorResponse>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        var authors = await unitOfWork.AuthorRepository.GetAll();
        var response = mapper.Map<List<AuthorResponse>>(authors);
        return new ApiResponse<List<AuthorResponse>>(response);
    }
}
