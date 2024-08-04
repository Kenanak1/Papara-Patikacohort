using AutoMapper;
using Papara_cohort;
using Papara_cohort.DTO;
using Papara_cohort.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara_cohort.MapperConfig;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Book, BookResponse>();
        CreateMap<BookRequest, Book>();

        CreateMap<Author, AuthorResponse>();
        CreateMap<AuthorRequest, Author>();

        CreateMap<Genre, GenreResponse>();
        CreateMap<GenreRequest, Genre>();


    }
}
