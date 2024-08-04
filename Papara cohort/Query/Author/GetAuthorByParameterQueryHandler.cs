using AutoMapper;
using MediatR;
using Papara_cohort.DTO;
using Papara_cohort.Cqrs;
using Papara_cohort.UnitOfWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAuthorByParameterQueryHandler : IRequestHandler<GetAuthorByParameterQuery, ApiResponse<AuthorResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAuthorByParameterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<AuthorResponse>> Handle(GetAuthorByParameterQuery request, CancellationToken cancellationToken)
    {
        // Tüm yazarları al
        var authors = await unitOfWork.AuthorRepository.GetAll();

        // Yazarları parametrelere göre filtrele
        var author = authors
            .FirstOrDefault(a => a.Id == request.AuthorId || a.Name == request.AuthorName);

        // Eğer yazar bulunamazsa hata yanıtı döndür
        if (author == null)
        {
            return new ApiResponse<AuthorResponse>("Author not found");
        }

        // Yazar bilgilerini DTO'ya dönüştür ve yanıt olarak döndür
        var response = mapper.Map<AuthorResponse>(author);
        return new ApiResponse<AuthorResponse>(response);
    }
}
