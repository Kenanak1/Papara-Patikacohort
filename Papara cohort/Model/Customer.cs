using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Papara_cohort.Controllers;

namespace Papara_cohort;

    public class Customer
    {
        [Required]
        [Range(minimum: 1, maximum: 10000)]
        [DisplayName("Customer id")]
        public int Id { get; set; }


        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [DisplayName("Customer name")]
        public string Name { get; set; }


        [Required]
        [Range(minimum: 18, maximum: 150)]
        [DisplayName("Customer Age")]
        public int Age { get; set; }

    }
    public class CustomerUpdateModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [DisplayName("Customer name")]
        public string Name { get; set; }

        [Range(minimum: 18, maximum: 150)]
        [DisplayName("Customer Age")]
        public int? Age { get; set; }
    }
