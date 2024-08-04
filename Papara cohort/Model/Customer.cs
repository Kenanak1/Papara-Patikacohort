using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Papara_cohort.Controllers;
using Papara_cohort.Base;

namespace Papara_cohort;

    public class Customer : BaseEntity
{

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
    public class CustomerUpdateModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [DisplayName("Customer name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

    [Range(minimum: 18, maximum: 150)]
        [DisplayName("Customer Age")]
        public int? Age { get; set; }
    }
