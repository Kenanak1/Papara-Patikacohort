using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Papara_cohort.Model;
using System.Threading;
using System.Threading.Tasks;
using Papara_cohort.Cqrs;

public class GenreCommandHandler :
    IRequestHandler<CreateGenreCommand, ApiResponse<GenreResponse>>,
    IRequestHandler<UpdateGenreCommand, ApiResponse>,
    IRequestHandler<DeleteGenreCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<GenreResponse>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = mapper.Map<Genre>(request.Request);
        await unitOfWork.GenreRepository.Insert(genre);
        await unitOfWork.Complete();
        var response = mapper.Map<GenreResponse>(genre);
        return new ApiResponse<GenreResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await unitOfWork.GenreRepository.GetById(request.GenreId);
        if (genre == null)
            return new ApiResponse { Success = false, Message = "Genre not found" };

        mapper.Map(request.Request, genre);
        unitOfWork.GenreRepository.Update(genre);
        await unitOfWork.Complete();
        return new ApiResponse { Success = true };
    }

    public async Task<ApiResponse> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.GenreRepository.Delete(request.GenreId);
        await unitOfWork.Complete();
        return new ApiResponse { Success = true };
    }
}
