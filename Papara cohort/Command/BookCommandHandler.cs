using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.UnitOfWork;
using Papara_cohort.Model;
using System.Threading;
using System.Threading.Tasks;
using Papara_cohort.Cqrs;

public class BookCommandHandler :
    IRequestHandler<CreateBookCommand, ApiResponse<BookResponse>>,
    IRequestHandler<UpdateBookCommand, ApiResponse>,
    IRequestHandler<DeleteBookCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public BookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<BookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var mappedBook = mapper.Map<Book>(request.Request);
        await unitOfWork.BookRepository.Insert(mappedBook);
        await unitOfWork.Complete();

        var response = mapper.Map<BookResponse>(mappedBook);
        return new ApiResponse<BookResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var existingBook = await unitOfWork.BookRepository.GetById(request.BookId);
        if (existingBook == null)
            return new ApiResponse("Book not found");

        var updatedBook = mapper.Map(request.Request, existingBook);
        unitOfWork.BookRepository.Update(updatedBook);
        await unitOfWork.Complete();

        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BookRepository.Delete(request.BookId);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}
