using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papara_cohort.GenericRepository;
using Papara_cohort.UnitOfWork;
using Papara_cohort;
using Papara_cohort.Context;
using Papara_cohort.Model;

namespace Papara_cohort.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PaparacohortDbContext dbContext;

    public IGenericRepository<Book> BookRepository { get; }

    public IGenericRepository<Author> AuthorRepository { get; }

    public IGenericRepository<Genre> GenreRepository { get; }




    public UnitOfWork(PaparacohortDbContext dbContext)
    {
        this.dbContext = dbContext;

        BookRepository = new GenericRepository<Book>(this.dbContext);
        AuthorRepository = new GenericRepository<Author>(this.dbContext);
        GenreRepository = new GenericRepository<Genre>(this.dbContext);
    }

    public async Task Complete()
    {
        await dbContext.SaveChangesAsync();
    }
    public async Task CompleteWithTransaction()
    {
        using (var dbTransaction = await dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw;
            }
        }
    }

    public void Dispose()
    {

    }



}
