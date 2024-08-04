using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papara_cohort.GenericRepository;
using Papara_cohort.Model;

namespace Papara_cohort.UnitOfWork;

public interface IUnitOfWork
{
    Task Complete();
    Task CompleteWithTransaction();


    IGenericRepository<Book> BookRepository { get; }
    IGenericRepository<Author> AuthorRepository { get; }
    IGenericRepository<Genre> GenreRepository { get; }

}
