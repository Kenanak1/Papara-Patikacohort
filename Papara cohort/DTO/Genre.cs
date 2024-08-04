using Papara_cohort.Base;
using Papara_cohort.Model;
namespace Papara_cohort.DTO;

public class GenreResponse : BaseEntity
{
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; }
}
public class GenreRequest : BaseEntity
{
    public string Name { get; set; }
}

