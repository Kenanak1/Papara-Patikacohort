using Papara_cohort.DTO;
using MediatR;
namespace Papara_cohort.Cqrs;

public record CreateAuthorCommand(AuthorRequest Request) : IRequest<ApiResponse<AuthorResponse>>;
public record UpdateAuthorCommand(int AuthorId, AuthorRequest Request) : IRequest<ApiResponse>;
public record DeleteAuthorCommand(int AuthorId) : IRequest<ApiResponse>;

public record GetAllAuthorQuery() : IRequest<ApiResponse<List<AuthorResponse>>>;
public record GetAuthorByIdQuery(int AuthorId) : IRequest<ApiResponse<AuthorResponse>>;
public record GetAuthorByParameterQuery(int AuthorId, string AuthorName) : IRequest<ApiResponse<AuthorResponse>>;
