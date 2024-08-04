using Papara_cohort.DTO;
using MediatR;
namespace Papara_cohort.Cqrs;

public record CreateGenreCommand(GenreRequest Request) : IRequest<ApiResponse<GenreResponse>>;
public record UpdateGenreCommand(int GenreId, GenreRequest Request) : IRequest<ApiResponse>;
public record DeleteGenreCommand(int GenreId) : IRequest<ApiResponse>;

public record GetAllGenreQuery() : IRequest<ApiResponse<List<GenreResponse>>>;
public record GetGenreByIdQuery(int GenreId) : IRequest<ApiResponse<GenreResponse>>;
public record GetGenreByParameterQuery(int GenreId, string GenreName) : IRequest<ApiResponse<GenreResponse>>;
