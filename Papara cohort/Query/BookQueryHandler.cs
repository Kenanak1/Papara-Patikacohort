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

public class BookQueryHandler :
    IRequestHandler<GetAllBooksQuery, ApiResponse<List<BookResponse>>>,
    IRequestHandler<GetBookByIdQuery, ApiResponse<BookResponse>>,
    IRequestHandler<GetBookByParameterQuery, ApiResponse<BookResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public BookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<BookResponse>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await unitOfWork.BookRepository.GetAll();
        var response = mapper.Map<List<BookResponse>>(books);
        return new ApiResponse<List<BookResponse>>(response);
    }

    public async Task<ApiResponse<BookResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await unitOfWork.BookRepository.GetById(request.BookId);
        if (book == null)
            return new ApiResponse<BookResponse>("Book not found");

        var response = mapper.Map<BookResponse>(book);
        return new ApiResponse<BookResponse>(response);
    }

    public async Task<ApiResponse<BookResponse>> Handle(GetBookByParameterQuery request, CancellationToken cancellationToken)
    {
        var books = await unitOfWork.BookRepository.GetAll();
        var book = books.FirstOrDefault(b => b.Id == request.BookId || b.Title.Equals(request.BookTitle, StringComparison.OrdinalIgnoreCase));
        if (book == null)
            return new ApiResponse<BookResponse>("Book not found");

        var response = mapper.Map<BookResponse>(book);
        return new ApiResponse<BookResponse>(response);
    }
}
