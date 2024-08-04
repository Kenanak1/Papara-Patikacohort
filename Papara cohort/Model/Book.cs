using Papara_cohort.Base;

namespace Papara_cohort.Model;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    public virtual string AuthorName { get; set; }
    public Author Author { get; set; }
    public virtual string GenreName { get; set; }
    public Genre Genre { get; set; }

  
   

    
}
