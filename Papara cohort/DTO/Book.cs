using Papara_cohort.Base;
using Papara_cohort.Model;

namespace Papara_cohort.DTO;

public class BookResponse : BaseEntity
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    public virtual string AuthorName { get; set; }
    public Author Author { get; set; }
    public virtual string GenreName { get; set; }
    public Genre Genre { get; set; }

}
public class BookRequest : BaseEntity
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
}


