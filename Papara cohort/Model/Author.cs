using Papara_cohort.Base;

namespace Papara_cohort.Model;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual List<Book> Books { get; set; }
}
