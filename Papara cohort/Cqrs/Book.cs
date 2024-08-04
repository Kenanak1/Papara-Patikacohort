using Papara_cohort.DTO;
using MediatR;
namespace Papara_cohort.Cqrs;

public record CreateBookCommand(BookRequest Request) : IRequest<ApiResponse<BookResponse>>;
public record UpdateBookCommand(int BookId, BookRequest Request) : IRequest<ApiResponse>;
public record DeleteBookCommand(int BookId) : IRequest<ApiResponse>;

public record GetAllBooksQuery() : IRequest<ApiResponse<List<BookResponse>>>;
public record GetBookByIdQuery(int BookId) : IRequest<ApiResponse<BookResponse>>;
public record GetBookByParameterQuery(int BookId, string BookTitle, string BookAuthor) : IRequest<ApiResponse<BookResponse>>;
