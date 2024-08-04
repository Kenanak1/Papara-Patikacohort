using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Papara_cohort.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Papara_cohort.Cqrs;

public class GenreQueryHandler :
    IRequestHandler<GetAllGenreQuery, ApiResponse<List<GenreResponse>>>,
    IRequestHandler<GetGenreByIdQuery, ApiResponse<GenreResponse>>,
    IRequestHandler<GetGenreByParameterQuery, ApiResponse<GenreResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<GenreResponse>>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
    {
        var genres = await unitOfWork.GenreRepository.GetAll();
        var response = mapper.Map<List<GenreResponse>>(genres);
        return new ApiResponse<List<GenreResponse>>(response);
    }

    public async Task<ApiResponse<GenreResponse>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await unitOfWork.GenreRepository.GetById(request.GenreId);
        if (genre == null)
            return new ApiResponse<GenreResponse>("Genre not found");

        var response = mapper.Map<GenreResponse>(genre);
        return new ApiResponse<GenreResponse>(response);
    }

    public async Task<ApiResponse<GenreResponse>> Handle(GetGenreByParameterQuery request, CancellationToken cancellationToken)
    {
        var genres = await unitOfWork.GenreRepository.GetAll();
        var genre = genres.FirstOrDefault(g => g.Id == request.GenreId || g.Name.Equals(request.GenreName, StringComparison.OrdinalIgnoreCase));
        if (genre == null)
            return new ApiResponse<GenreResponse>("Genre not found");

        var response = mapper.Map<GenreResponse>(genre);
        return new ApiResponse<GenreResponse>(response);
    }
}
