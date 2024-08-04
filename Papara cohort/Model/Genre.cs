using Papara_cohort.Base;

namespace Papara_cohort.Model;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    public virtual List<Book> Books { get; set; }


}
