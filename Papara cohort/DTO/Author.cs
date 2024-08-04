using Papara_cohort.Base;
using Papara_cohort.Model;

namespace Papara_cohort.DTO;

public class AuthorResponse : BaseEntity
{

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual List<Book> Books { get; set; }
   

}
public class AuthorRequest : BaseEntity
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
}


